using System;
using System.Collections.Generic;
using System.Linq;
using Lalogo.InstantPublisher.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Lalogo.InstantPublisher.Services
{
    public class SolutionService
    {
        private readonly IOrganizationService _service;

        public SolutionService(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public List<SolutionReference> GetSolutions(string searchText)
        {
            var query = new QueryExpression("solution")
            {
                ColumnSet = new ColumnSet("solutionid", "friendlyname", "uniquename", "version", "ismanaged", "isvisible"),
                Criteria = new FilterExpression(LogicalOperator.And),
                Orders = { new OrderExpression("friendlyname", OrderType.Ascending) }
            };

            query.Criteria.AddCondition("isvisible", ConditionOperator.Equal, true);
            query.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, false);
            query.Criteria.AddCondition("uniquename", ConditionOperator.NotEqual, "Default");
            query.Criteria.AddCondition("uniquename", ConditionOperator.NotEqual, "Active");

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var like = "%" + searchText.Trim() + "%";
                var searchFilter = new FilterExpression(LogicalOperator.Or);
                searchFilter.AddCondition("friendlyname", ConditionOperator.Like, like);
                searchFilter.AddCondition("uniquename", ConditionOperator.Like, like);
                query.Criteria.AddFilter(searchFilter);
            }

            return _service
                .RetrieveMultiple(query)
                .Entities
                .Select(e => new SolutionReference
                {
                    Id = e.Id,
                    FriendlyName = e.GetAttributeValue<string>("friendlyname"),
                    UniqueName = e.GetAttributeValue<string>("uniquename"),
                    Version = e.GetAttributeValue<string>("version")
                })
                .ToList();
        }

        public HashSet<Guid> GetComponentIdsInSolution(Guid solutionId, int componentType)
        {
            var query = new QueryExpression("solutioncomponent")
            {
                ColumnSet = new ColumnSet("objectid"),
                Criteria = new FilterExpression(LogicalOperator.And)
                {
                    Conditions =
                    {
                        new ConditionExpression("solutionid", ConditionOperator.Equal, solutionId),
                        new ConditionExpression("componenttype", ConditionOperator.Equal, componentType)
                    }
                }
            };

            var ids = new HashSet<Guid>();
            var results = _service.RetrieveMultiple(query).Entities;
            foreach (var entity in results)
            {
                var objectId = entity.GetAttributeValue<Guid?>("objectid");
                if (objectId.HasValue)
                    ids.Add(objectId.Value);
            }

            return ids;
        }

        public void AddComponentToSolution(string solutionUniqueName, int componentType, Guid componentId)
        {
            var request = new OrganizationRequest("AddSolutionComponent");
            request["SolutionUniqueName"] = solutionUniqueName;
            request["ComponentType"] = componentType;
            request["ComponentId"] = componentId;
            request["AddRequiredComponents"] = false;

            _service.Execute(request);
        }
    }
}

using System;

namespace Lalogo.InstantPublisher.Models
{
    public class SelectableSolutionComponent
    {
        public Guid ComponentId { get; set; }
        public int ComponentType { get; set; }
        public string Name { get; set; }
        public string TypeLabel { get; set; }
        public bool IsAlreadyInSolution { get; set; }
        public bool IsSelected { get; set; }

        public bool CanSelect
        {
            get { return !IsAlreadyInSolution; }
        }

        public string StatusLabel
        {
            get { return IsAlreadyInSolution ? "Already in solution" : "Available"; }
        }
    }
}

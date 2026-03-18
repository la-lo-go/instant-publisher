using System;
using System.Collections.Generic;

namespace Lalogo.InstantPublisher
{
    public class MonitoredWebResource
    {
        public string FilePath { get; set; }
        public Guid WebResourceId { get; set; }
        public string WebResourceName { get; set; }
        public Guid? LastSolutionId { get; set; }
        public bool IsAuto { get; set; }
    }

    public class MonitoredPlugin
    {
        public string FilePath { get; set; }
        public bool IsAuto { get; set; }
    }

    public class MonitoredCollection
    {
        public List<MonitoredWebResource> WebResources { get; set; } = new List<MonitoredWebResource>();
        public List<MonitoredPlugin> Plugins { get; set; } = new List<MonitoredPlugin>();
    }
}

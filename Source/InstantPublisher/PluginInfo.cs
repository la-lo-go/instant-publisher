using System;

namespace Lalogo.InstantPublisher
{
    public class PluginInfo
    {
        public PluginViewControl Control { get; set; }

        public DateTime LastPublish { get; set; } = DateTime.Now;


        public Guid? PluginAssemblyId { get; set; }

    }
}
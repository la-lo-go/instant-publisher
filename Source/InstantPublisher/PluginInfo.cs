using System;

namespace Lalogo.InstantPublisher
{
    public class PluginInfo
    {
        public string FileName { get; set; }
        public bool IsAuto { get; set; }
        public bool IsBusy { get; set; }
        public bool IsDirty { get; set; }
        public string AssemblyVersion { get; set; }
        public string CrmVersion { get; set; }
        public DateTime LastPublish { get; set; } = DateTime.MinValue;
        public Guid? PluginAssemblyId { get; set; }
    }
}

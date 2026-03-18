using System;

namespace Lalogo.InstantPublisher
{
    public class WebResourceInfo
    {
        public string FileName { get; set; }
        public string WebResourceName { get; set; }
        public Guid WebResourceId { get; set; }
        public Guid? LastSolutionId { get; set; }
        public bool IsAuto { get; set; }
        public bool IsBusy { get; set; }
        public bool IsDirty { get; set; }
        public DateTime LastPublish { get; set; } = DateTime.MinValue;
    }
}

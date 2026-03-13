using System;

namespace Lalogo.InstantPublisher
{
    public class WebResourceInfo
    {
        public WebResourceViewControl Control { get; set; }

        public Guid WebResourceId { get; set; }


        public DateTime LastPublish { get; set; } = DateTime.Now;
    }
}
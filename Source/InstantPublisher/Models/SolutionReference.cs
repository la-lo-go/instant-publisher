using System;

namespace Lalogo.InstantPublisher.Models
{
    public class SolutionReference
    {
        public Guid Id { get; set; }
        public string FriendlyName { get; set; }
        public string UniqueName { get; set; }
        public string Version { get; set; }

        public string DisplayName
        {
            get
            {
                var title = string.IsNullOrWhiteSpace(FriendlyName) ? UniqueName : FriendlyName;
                var versionSuffix = string.IsNullOrWhiteSpace(Version) ? string.Empty : " (" + Version + ")";
                return title + versionSuffix;
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}

using System.Collections.Generic;

namespace Document.Core.Models.Options
{
    public class ImageSettings
    {
        public long MaximumLengthInBytes { get; set; }
        public List<string> AllowedContentTypes { get; set; }
        public string DefaultContainer { get; set; }
    }
}

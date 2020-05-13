using MicroBank.Common.Models;
using System;

namespace Client.Core.Entities.Client
{
    public class Document : BaseEntity<Guid>
    {
        public Uri Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

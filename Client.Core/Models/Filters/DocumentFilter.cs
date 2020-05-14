using MicroBank.Common.Models;
using System;

namespace Client.Core.Models.Filters
{
    public class DocumentFilter : BaseFilter
    {
        public Guid? ClientId { get; set; }
    }
}

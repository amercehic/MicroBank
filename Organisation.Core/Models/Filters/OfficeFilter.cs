using MicroBank.Common.Models;
using System;

namespace Organisation.Core.Models.Filters
{
    public class OfficeFilter : BaseFilter
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public bool? IsMainOffice { get; set; }
    }
}

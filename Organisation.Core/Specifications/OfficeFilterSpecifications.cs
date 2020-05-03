using MicroBank.Common.Specification;
using Organisation.Core.Entities;
using Organisation.Core.Models.Filters;

namespace Organisation.Core.Specifications
{
    public class OfficeFilterSpecifications : BaseSpecification<Office>
    {
        public OfficeFilterSpecifications(OfficeFilter filter) : base(s =>
            (string.IsNullOrEmpty(filter.Name) || s.Name.ToLower().Trim().Contains(filter.Name.ToLower().Trim())) &&
            (!filter.ParentId.HasValue || s.ParentId.Equals(filter.ParentId)) &&
            (string.IsNullOrEmpty(filter.SearchTerm) || s.Name.ToLower().Trim().Contains(filter.SearchTerm.ToLower().Trim()))
        )
        {
            ApplyPaging(filter.Page * filter.PageSize, filter.PageSize);
            ApplyOrderByDescending(s => s.CreatedAt);
        }
    }
}

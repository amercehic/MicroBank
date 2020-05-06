using MicroBank.Common.Specification;
using Organisation.Core.Entities;
using Organisation.Core.Models.Filters;

namespace Organisation.Core.Specifications
{
    public class StaffMemberFilterSpecifications : BaseSpecification<StaffMember>
    {
        public StaffMemberFilterSpecifications(StaffMemberFilter filter) : base(s =>
            (string.IsNullOrEmpty(filter.FirstName) || s.FirstName.ToLower().Trim().Contains(filter.FirstName.ToLower().Trim())) &&
            (string.IsNullOrEmpty(filter.LastName) || s.LastName.ToLower().Trim().Contains(filter.LastName.ToLower().Trim())) &&
            (string.IsNullOrEmpty(filter.OfficeName) || s.Office.Name.ToLower().Trim().Contains(filter.OfficeName.ToLower().Trim())) &&
            (string.IsNullOrEmpty(filter.SearchTerm) || s.FirstName.ToLower().Trim().Contains(filter.SearchTerm.ToLower().Trim()))
        )
        {
            ApplyPaging(filter.Page * filter.PageSize, filter.PageSize);
            ApplyOrderByDescending(s => s.CreatedAt);
            AddInclude(o => o.Office);
        }
    }
}

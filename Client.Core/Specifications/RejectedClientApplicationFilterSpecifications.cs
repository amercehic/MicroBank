using Client.Core.Entities.Client;
using Client.Core.Models.Filters;
using MicroBank.Common.Specification;

namespace Client.Core.Specifications
{
    public class RejectedClientApplicationFilterSpecifications : BaseSpecification<RejectedClientApplication>
    {
        public RejectedClientApplicationFilterSpecifications(RejectedClientApplicationFilter filter) : base(s =>
        (string.IsNullOrEmpty(filter.Reason) || s.Reason.ToLower().Trim().Contains(filter.Reason.ToLower().Trim())))
        {
            ApplyPaging(filter.Page * filter.PageSize, filter.PageSize);
            ApplyOrderByDescending(s => s.CreatedAt);
            AddInclude(o => o.ClientApplication);
        }
    }
}

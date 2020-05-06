using Client.Core.Models.Filters;
using MicroBank.Common.Specification;

namespace Client.Core.Specifications
{
    public class ClientFilterspecifications : BaseSpecification<Entities.Client.Client>
    {
        public ClientFilterspecifications(ClientFilter filter) : base(s =>
            (string.IsNullOrEmpty(filter.FirstName) || s.FirstName.ToLower().Trim().Contains(filter.FirstName.ToLower().Trim())) &&
            (string.IsNullOrEmpty(filter.LastName) || s.LastName.ToLower().Trim().Contains(filter.LastName.ToLower().Trim())) &&
            (string.IsNullOrEmpty(filter.SearchTerm) || s.FirstName.ToLower().Trim().Contains(filter.SearchTerm.ToLower().Trim()))
        )
        {
            ApplyPaging(filter.Page * filter.PageSize, filter.PageSize);
            ApplyOrderByDescending(s => s.CreatedAt);
            AddInclude(o => o.ClientAddressData);
            AddInclude(o => o.ClientFamilyDetailsData);
            AddInclude(o => o.ClientContactData);
            AddInclude(o => o.ClientApplication);
        }
    }
}

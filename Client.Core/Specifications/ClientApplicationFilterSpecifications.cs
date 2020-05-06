using Client.Core.Entities;
using Client.Core.Models.Filters;
using MicroBank.Common.Specification;

namespace Client.Core.Specifications
{
    public class ClientApplicationFilterSpecifications : BaseSpecification<ClientApplication>
    {
        public ClientApplicationFilterSpecifications(ClientApplicationFilter filter) : base(s =>
            (string.IsNullOrEmpty(filter.FirstName) || s.FirstName.ToLower().Trim().Contains(filter.FirstName.ToLower().Trim())) &&
            (string.IsNullOrEmpty(filter.LastName) || s.LastName.ToLower().Trim().Contains(filter.LastName.ToLower().Trim())) &&
            (string.IsNullOrEmpty(filter.Status) || s.Status.ToLower().Trim().Contains(filter.Status.ToLower().Trim())) &&
            (string.IsNullOrEmpty(filter.Country) || s.ClientApplicationAddressData.Country.ToLower().Trim().Contains(filter.Country.ToLower().Trim())) &&
            (string.IsNullOrEmpty(filter.SearchTerm) || s.FirstName.ToLower().Trim().Contains(filter.SearchTerm.ToLower().Trim()))
        )
        {
            ApplyPaging(filter.Page * filter.PageSize, filter.PageSize);
            ApplyOrderByDescending(s => s.CreatedAt);
            AddInclude(o => o.ClientApplicationAddressData);
            AddInclude(o => o.ClientApplicationFamilyDetailsData);
            AddInclude(o => o.ClientApplicationContactData);
        }
    }
}

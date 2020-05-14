using Client.Core.Entities.Staff;
using Client.Core.Integrations.Services.OfficeApi;
using Client.Core.Integrations.Services.OrganisationApi.Exceptions;
using Client.Core.Interfaces.Repository;
using MicroBank.Common.Repository;
using System;
using System.Threading.Tasks;

namespace Client.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IEfRepository<StaffMember, Guid> _efRepository;
        private readonly IOrganisationApiService _organisationApiService;

        public ClientRepository(IEfRepository<StaffMember, Guid> efRepository, IOrganisationApiService organisationApiService)
        {
            _efRepository = efRepository;
            _organisationApiService = organisationApiService;
        }

        public async Task<StaffMember> CreateIfNotExists(Guid id)
        {
            var existingStaffMember = await _efRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (existingStaffMember != null)
            {
                return existingStaffMember;
            }

             var newMember = await _organisationApiService.GetStaffMemberByIdAsync(id).ConfigureAwait(true);

            if (newMember == null)
            {
                throw new StaffMemberNotFoundException(id: id.ToString());
            }

            var entity = new StaffMember()
            {
                Id = newMember.Id,
                FirstName = newMember.FirstName,
                LastName = newMember.LastName,
                IsLoanOfficer = newMember.IsLoanOfficer,
                IsActive = newMember.IsActive
            };

            return await _efRepository.AddAsync(entity).ConfigureAwait(true);
        }
    }
}

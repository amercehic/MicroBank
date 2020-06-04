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
        private readonly IEfRepository<Core.Entities.Client.PersonalClient, Guid> _clientEfRepository;
        private readonly IOrganisationApiService _organisationApiService;

        public ClientRepository(IEfRepository<StaffMember, Guid> efRepository, IOrganisationApiService organisationApiService, IEfRepository<Core.Entities.Client.PersonalClient, Guid> clientEfRepository)
        {
            _efRepository = efRepository;
            _organisationApiService = organisationApiService;
            _clientEfRepository = clientEfRepository;
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

        private static string GenerateNumber(int numberOfDigits)
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i <= numberOfDigits; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return r;
        }
    }
}

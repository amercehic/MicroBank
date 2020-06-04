using ChargeCardAccount.Core.Entities;
using ChargeCardAccount.Core.Integrations.Services.ClientApi;
using ChargeCardAccount.Core.Interfaces.Repository;
using MicroBank.Common.Repository;
using System;
using System.Threading.Tasks;

namespace ChargeCardAccount.Infrastructure.Repository
{
    public class ChargeCardAccountRepository : IChargeCardAccountRepository
    {
        private readonly IEfRepository<Client, Guid> _efRepository;
        private readonly IClientApiService _clientApiService;

        public ChargeCardAccountRepository(IEfRepository<Client, Guid> efRepository, IClientApiService clientApiService)
        {
            _efRepository = efRepository;
            _clientApiService = clientApiService;
        }

        public async Task<Client> CreateClientIfNotExists(Guid id)
        {
            var existingClient = await _efRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingClient != null)
            {
                return existingClient;
            }

            var clientFromService = await _clientApiService.GetClientByIdAsync(id).ConfigureAwait(true);

            var newClient = new Client()
            {
                Id = clientFromService.Id,
                FirstName = clientFromService.FirstName,
                LastName = clientFromService.LastName,
                DateOfBirth = clientFromService.DateOfBirth, 
                PersonalId = clientFromService.PersonalId,
                OfficeId = clientFromService.OfficeId,
                Status = clientFromService.Status
            };

            return await _efRepository.AddAsync(newClient).ConfigureAwait(true);
        }
    }
}

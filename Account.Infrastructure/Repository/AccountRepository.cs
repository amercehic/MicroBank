using Account.Core.Entities;
using Account.Core.Integrations.Services.ClientApi;
using Account.Core.Interfaces.Repository;
using MicroBank.Common.Repository;
using System;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IEfRepository<Client, Guid> _efRepository;
        private readonly IClientApiService _clientApiService;

        public AccountRepository(IEfRepository<Client, Guid> efRepository, IClientApiService clientApiService)
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

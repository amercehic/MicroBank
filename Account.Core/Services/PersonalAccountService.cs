using Account.Core.Integrations.Services.ClientApi;
using Account.Core.Integrations.Services.ClientApi.Exceptions;
using Account.Core.Interfaces.Repository;
using Account.Core.Interfaces.Service;
using Account.Core.Models.BindingModel;
using Account.Core.Models.Dto;
using Account.Core.Models.Filters;
using MicroBank.Common.Identity;
using MicroBank.Common.Models;
using MicroBank.Common.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Account.Core.Services
{
    public class PersonalAccountService : IPersonalAccountService
    {
        private readonly ClaimsPrincipalUtil _principal;
        private readonly IEfRepository<Core.Entities.MainAccount, Guid> _efAccountRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<PersonalAccountService> _logger;
        private readonly IClientApiService _clientApiService;

        public PersonalAccountService(
            ClaimsPrincipalUtil principal,
            IEfRepository<Core.Entities.MainAccount, Guid> efAccountRepository,
            IAccountRepository accountRepository,
            ILogger<PersonalAccountService> logger,
            IClientApiService clientApiService)
        {
            _principal = principal;
            _efAccountRepository = efAccountRepository;
            _accountRepository = accountRepository;
            _logger = logger;
            _clientApiService = clientApiService;
        }

        public Task<PersonalAccountDto> ActivatePersonalAccountAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonalAccountDto> ApprovePersonalAccountApplicationAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonalAccountDto> GeneratePersonalAccountApplicationAsync(PersonalAccountCreateBindingModel model)
        {
            _logger.LogInformation("Perfom creating of Account Application: {}", model);

            var client = await _clientApiService.GetClientByIdAsync(model.ClientId).ConfigureAwait(false);

            if (client == null)
            {
                throw new ClientNotFoundException(id: model.ClientId.ToString());
            }

            var clientFromRepo = await _accountRepository.CreateClientIfNotExists(model.ClientId.Value).ConfigureAwait(false);

            var accountApplication = new Core.Entities.MainAccount()
            {
                ClientId = clientFromRepo.Id
            };
            return new PersonalAccountDto();
        }

        public Task<PersonalAccountDto> GetAccountByClientAsync(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task<QueryResultDto<PersonalAccountDto, Guid>> GetByFilterAsync(PersonalAccountFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<PersonalAccountDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

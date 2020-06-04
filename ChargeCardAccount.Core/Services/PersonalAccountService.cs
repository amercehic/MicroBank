using ChargeCardAccount.Core.Integrations.Services.ClientApi;
using ChargeCardAccount.Core.Integrations.Services.ClientApi.Exceptions;
using ChargeCardAccount.Core.Interfaces.Repository;
using ChargeCardAccount.Core.Interfaces.Service;
using ChargeCardAccount.Core.Models.BindingModel;
using ChargeCardAccount.Core.Models.Dto;
using ChargeCardAccount.Core.Models.Filters;
using MicroBank.Common.Identity;
using MicroBank.Common.Models;
using MicroBank.Common.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ChargeCardAccount.Core.Services
{
    public class PersonalAccountService : IPersonalChargeCardAccountService
    {
        private readonly ClaimsPrincipalUtil _principal;
        private readonly IEfRepository<Core.Entities.Account, Guid> _efAccountRepository;
        private readonly IChargeCardAccountRepository _accountRepository;
        private readonly ILogger<PersonalAccountService> _logger;
        private readonly IClientApiService _clientApiService;

        public PersonalAccountService(
            ClaimsPrincipalUtil principal,
            IEfRepository<Core.Entities.Account, Guid> efAccountRepository,
            IChargeCardAccountRepository accountRepository,
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

            var accountApplication = new Core.Entities.Account()
            {
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

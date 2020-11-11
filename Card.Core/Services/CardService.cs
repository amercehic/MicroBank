using Card.Core.Interfaces.Service;
using Card.Core.Models.BindingModel;
using Card.Core.Models.Dto;
using MicroBank.Common.Identity;
using MicroBank.Common.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Card.Core.Services
{
    public class CardService : ICardService
    {
        private readonly ClaimsPrincipalUtil principal;
        private readonly IEfRepository<Core.Entities.Card, Guid> efRepository;
        private readonly ILogger<CardService> logger;

        public CardService(
            ClaimsPrincipalUtil principal,
            IEfRepository<Core.Entities.Card, Guid> efRepository,
            ILogger<CardService> logger)
        {
            this.principal = principal;
            this.efRepository = efRepository;
            this.logger = logger;
        }

        public Task<CardDto> ActivateCardAsync(CardPatchBindingModel model)
        {
            throw new NotImplementedException();
        }

        public Task<CardDto> ChangePinAsync(CardPatchBindingModel model)
        {
            throw new NotImplementedException();
        }

        public Task<CardDto> CreateCardAsync(CardCreateBindingModel model)
        {
            throw new NotImplementedException();
        }

        public Task<CardDto> DeactivateCardAsync(CardPatchBindingModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CardDto> GetByAccountIdAsync(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public Task<CardDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

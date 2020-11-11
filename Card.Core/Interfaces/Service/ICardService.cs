using Card.Core.Models.BindingModel;
using Card.Core.Models.Dto;
using System;
using System.Threading.Tasks;

namespace Card.Core.Interfaces.Service
{
    public interface ICardService
    {
        Task<CardDto> GetByIdAsync(Guid id);
        Task<CardDto> GetByAccountIdAsync(Guid accountId);
        Task<CardDto> CreateCardAsync(CardCreateBindingModel model);
        Task<CardDto> ActivateCardAsync(CardPatchBindingModel model);
        Task<CardDto> ChangePinAsync(CardPatchBindingModel model);
        Task<CardDto> DeactivateCardAsync(CardPatchBindingModel model);
        Task DeleteAsync(Guid id);
    }
}

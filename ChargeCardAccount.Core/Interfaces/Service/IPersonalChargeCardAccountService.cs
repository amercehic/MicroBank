using ChargeCardAccount.Core.Models.BindingModel;
using ChargeCardAccount.Core.Models.Dto;
using ChargeCardAccount.Core.Models.Filters;
using MicroBank.Common.Models;
using System;
using System.Threading.Tasks;

namespace ChargeCardAccount.Core.Interfaces.Service
{
    public interface IPersonalChargeCardAccountService
    {
        Task<PersonalAccountDto> GetByIdAsync(Guid id);
        Task<QueryResultDto<PersonalAccountDto, Guid>> GetByFilterAsync(PersonalAccountFilter filter);
        Task<PersonalAccountDto> ApprovePersonalAccountApplicationAsync(Guid id);
        Task<PersonalAccountDto> GeneratePersonalAccountApplicationAsync(PersonalAccountCreateBindingModel model);
        Task<PersonalAccountDto> ActivatePersonalAccountAsync(Guid id);
        Task<PersonalAccountDto> GetAccountByClientAsync(string clientId);
    }
}

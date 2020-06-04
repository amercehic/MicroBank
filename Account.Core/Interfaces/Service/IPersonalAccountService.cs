using Account.Core.Models.BindingModel;
using Account.Core.Models.Dto;
using Account.Core.Models.Filters;
using MicroBank.Common.Models;
using System;
using System.Threading.Tasks;

namespace Account.Core.Interfaces.Service
{
    public interface IPersonalAccountService
    {
        Task<PersonalAccountDto> GetByIdAsync(Guid id);
        Task<QueryResultDto<PersonalAccountDto, Guid>> GetByFilterAsync(PersonalAccountFilter filter);
        Task<PersonalAccountDto> ApprovePersonalAccountApplicationAsync(Guid id);
        Task<PersonalAccountDto> GeneratePersonalAccountApplicationAsync(PersonalAccountCreateBindingModel model);
        Task<PersonalAccountDto> ActivatePersonalAccountAsync(Guid id);
        Task<PersonalAccountDto> GetAccountByClientAsync(string clientId);
    }
}

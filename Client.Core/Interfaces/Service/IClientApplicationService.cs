using Client.Core.Models.BindingModel;
using Client.Core.Models.Dto;
using Client.Core.Models.Filters;
using MicroBank.Common.Models;
using System;
using System.Threading.Tasks;

namespace Client.Core.Interfaces.Service
{
    public interface IClientApplicationService
    {
        Task<ClientApplicationDto> GetByIdAsync(Guid id);
        Task<QueryResultDto<ClientApplicationDto, Guid>> GetByFilterAsync(ClientApplicationFilter filter);
        Task<ClientApplicationDto> CreateAsync(ClientApplicationCreateBindingModel model);
        Task<ClientApplicationDto> UpdateAsync(Guid id, ClientApplicationPatchBindingModel model);
        Task DeleteAsync(Guid id);
    }
}

using Client.Core.Models.BindingModel;
using Client.Core.Models.BindingModel.ClientApplication;
using Client.Core.Models.Dto.Client;
using Client.Core.Models.Dto.ClientApplication;
using Client.Core.Models.Filters;
using MicroBank.Common.Models;
using System;
using System.Threading.Tasks;

namespace Client.Core.Interfaces.Service
{
    public interface IClientService
    {
        Task<ClientDto> GetByIdAsync(Guid id);
        Task<QueryResultDto<ClientDto, Guid>> GetByFilterAsync(ClientFilter filter);
        Task<ClientDto> CreateAsync(Guid id);
        Task<ClientDto> UpdateAsync(Guid id, ClientPatchBindingModel model);
        Task<ClientDto> ApproveClientApplicationAsync(Guid id);
        Task<RejectedClientApplicationDto> RejectClientApplicationAsync(Guid id, RejectedClientApplicationCreateBindingModel model);
    }
}

using Client.Core.Models.BindingModel;
using Client.Core.Models.BindingModel.ClientApplication;
using Client.Core.Models.Dto.Client;
using Client.Core.Models.Dto.ClientApplication;
using System;
using System.Threading.Tasks;

namespace Client.Core.Interfaces.Service
{
    public interface IClientService
    {
        Task<ClientDto> GetByIdAsync(Guid id);
        Task<ClientDto> CreateAsync(ClientApplicationCreateBindingModel model);
        Task<ClientDto> ApproveClientApplicationAsync(Guid id);
        Task<RejectedClientApplicationDto> RejectClientApplicationAsync(Guid id, RejectedClientApplicationCreateBindingModel model);
        Task<ClientDto> GenerateClientApplicationAsync(ClientApplicationCreateBindingModel model);
        Task<ClientDto> ActivateClientAsync(Guid id);
    }
}

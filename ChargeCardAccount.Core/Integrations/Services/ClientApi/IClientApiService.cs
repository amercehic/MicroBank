using ChargeCardAccount.Core.Integrations.Services.ClientApi.Models;
using System;
using System.Threading.Tasks;

namespace ChargeCardAccount.Core.Integrations.Services.ClientApi
{
    public interface IClientApiService
    {
        Task<ClientDto> GetClientByIdAsync(Guid? id);
    }
}

using Organisation.Core.Integrations.Services.ClientApi.Models;
using System;
using System.Threading.Tasks;

namespace Organisation.Core.Integrations.Services.ClientApi
{
    public interface IClientApiService
    {
        Task<ClientDto> GetByIdAsync(Guid id);
    }
}

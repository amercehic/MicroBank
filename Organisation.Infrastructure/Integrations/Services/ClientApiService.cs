using Newtonsoft.Json;
using Organisation.Core.Integrations.Services.ClientApi;
using Organisation.Core.Integrations.Services.ClientApi.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Organisation.Infrastructure.Integrations.Services
{
    public class ClientApiService : IClientApiService
    {
        private readonly HttpClient _httpClient;

        public ClientApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ClientDto> GetByIdAsync(Guid id)
        {
            return JsonConvert.DeserializeObject<ClientDto>(await _httpClient.GetStringAsync($"api/client/{id}").ConfigureAwait(false));
        }
    }
}

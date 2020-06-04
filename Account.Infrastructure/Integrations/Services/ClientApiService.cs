using Account.Core.Integrations.Services.ClientApi;
using Account.Core.Integrations.Services.ClientApi.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Account.Infrastructure.Integrations.Services
{
    public class ClientApiService : IClientApiService
    {
        private readonly HttpClient _httpClient;

        public ClientApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ClientDto> GetClientByIdAsync(Guid? id)
        {
            return JsonConvert.DeserializeObject<ClientDto>(await _httpClient.GetStringAsync($"api/client/{id}").ConfigureAwait(false));
        }
    }
}

using Client.Core.Integrations.Services.OfficeApi;
using Client.Core.Integrations.Services.OfficeApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure.Integrations.Services
{
    public class OfficeApiService : IOfficeApiService
    {
        private readonly HttpClient _httpClient;

        public OfficeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OfficeDto> GetByIdAsync(Guid id)
        {
            return JsonConvert.DeserializeObject<OfficeDto>(await _httpClient.GetStringAsync($"api/office/{id}").ConfigureAwait(false));
        }
    }
}

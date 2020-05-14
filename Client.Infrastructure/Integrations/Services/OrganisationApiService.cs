using Client.Core.Integrations.Services.OfficeApi;
using Client.Core.Integrations.Services.OfficeApi.Models;
using Client.Core.Integrations.Services.OrganisationApi.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Infrastructure.Integrations.Services
{
    public class OrganisationApiService : IOrganisationApiService
    {
        private readonly HttpClient _httpClient;

        public OrganisationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OfficeDto> GetOfficeByIdAsync(Guid id)
        {
            return JsonConvert.DeserializeObject<OfficeDto>(await _httpClient.GetStringAsync($"api/office/{id}").ConfigureAwait(false));
        }

        public async Task<StaffMemberDto> GetStaffMemberByIdAsync(Guid id)
        {
            return JsonConvert.DeserializeObject<StaffMemberDto>(await _httpClient.GetStringAsync($"api/StaffMember/{id}").ConfigureAwait(false));
        }
    }
}

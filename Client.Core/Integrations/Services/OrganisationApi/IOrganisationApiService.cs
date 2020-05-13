using Client.Core.Entities.Staff;
using Client.Core.Integrations.Services.OfficeApi.Models;
using Client.Core.Integrations.Services.OrganisationApi.Models;
using System;
using System.Threading.Tasks;

namespace Client.Core.Integrations.Services.OfficeApi
{
    public interface IOrganisationApiService
    {
        Task<OfficeDto> GetOfficeByIdAsync(Guid id);
        Task<StaffMemberDto> GetStaffMemberByIdAsync(Guid id);
    }
}

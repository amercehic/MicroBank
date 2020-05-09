using Client.Core.Integrations.Services.OfficeApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Integrations.Services.OfficeApi
{
    public interface IOfficeApiService
    {
        Task<OfficeDto> GetByIdAsync(Guid id);
    }
}

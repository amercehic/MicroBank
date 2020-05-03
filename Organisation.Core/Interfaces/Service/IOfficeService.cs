using MicroBank.Common.Models;
using Organisation.Core.Models.BindingModel;
using Organisation.Core.Models.Dto;
using Organisation.Core.Models.Filters;
using System;
using System.Threading.Tasks;

namespace Organisation.Core.Interfaces.Service
{
    public interface IOfficeService
    {
        Task<OfficeDto> GetByIdAsync(Guid id);
        Task<QueryResultDto<OfficeDto, Guid>> GetByFilterAsync(OfficeFilter filter);
        Task<OfficeDto> CreateAsync(OfficeCreateBindingModel model);
        Task<OfficeDto> UpdateAsync(Guid id, OfficePatchBindingModel model);
        Task DeleteAsync(Guid id);
    }
}

using MicroBank.Common.Models;
using Organisation.Core.Models.BindingModel;
using Organisation.Core.Models.Dto;
using Organisation.Core.Models.Filters;
using System;
using System.Threading.Tasks;

namespace Organisation.Core.Interfaces.Service
{
    public interface IStaffMemberService
    {
        Task<StaffMemberDto> GetByIdAsync(Guid id);
        Task<QueryResultDto<StaffMemberDto, Guid>> GetByFilterAsync(StaffMemberFilter filter);
        Task<StaffMemberDto> CreateAsync(StaffMemberCreateBindingModel model);
        Task<StaffMemberDto> UpdateAsync(Guid id, StaffMemberPatchBindingModel model);
        Task DeleteAsync(Guid id);
    }
}

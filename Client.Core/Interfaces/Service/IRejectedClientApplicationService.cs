using Client.Core.Models.Dto.ClientApplication;
using Client.Core.Models.Filters;
using MicroBank.Common.Models;
using System;
using System.Threading.Tasks;

namespace Client.Core.Interfaces.Service
{
    public interface IRejectedClientApplicationService
    {
        Task<RejectedClientApplicationDto> GetByIdAsync(Guid id);
        Task<QueryResultDto<RejectedClientApplicationDto, Guid>> GetByFilterAsync(RejectedClientApplicationFilter filter);
    }
}

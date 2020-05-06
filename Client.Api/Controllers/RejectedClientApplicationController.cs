using System;
using System.Threading.Tasks;
using Client.Core.Interfaces.Service;
using Client.Core.Models.Dto.ClientApplication;
using Client.Core.Models.Filters;
using MicroBank.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RejectedClientApplicationController : ControllerBase
    {
        private readonly IRejectedClientApplicationService service;

        public RejectedClientApplicationController(IRejectedClientApplicationService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<RejectedClientApplicationDto> Get(Guid id)
        {
            return await service.GetByIdAsync(id).ConfigureAwait(false);
        }

        [HttpGet("GetByQuery")]
        public async Task<QueryResultDto<RejectedClientApplicationDto, Guid>> GetByQuery([FromQuery] RejectedClientApplicationFilter model)
        {
            return await service.GetByFilterAsync(model).ConfigureAwait(false);
        }
    }
}
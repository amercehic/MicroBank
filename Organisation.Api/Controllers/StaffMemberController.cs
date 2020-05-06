using MicroBank.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Organisation.Core.Interfaces.Service;
using Organisation.Core.Models.BindingModel;
using Organisation.Core.Models.Dto;
using Organisation.Core.Models.Filters;
using System;
using System.Threading.Tasks;

namespace Organisation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffMemberController : ControllerBase
    {
        private readonly IStaffMemberService service;

        public StaffMemberController(IStaffMemberService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<StaffMemberDto> Get(Guid id)
        {
            return await service.GetByIdAsync(id).ConfigureAwait(false);
        }

        [HttpGet("GetByQuery")]
        public async Task<QueryResultDto<StaffMemberDto, Guid>> GetByQuery([FromQuery] StaffMemberFilter model)
        {
            return await service.GetByFilterAsync(model).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<StaffMemberDto> Create(StaffMemberCreateBindingModel model)
        {
            return await service.CreateAsync(model).ConfigureAwait(false);
        }

        [HttpPatch("{id}")]
        public async Task<StaffMemberDto> Update(Guid id, StaffMemberPatchBindingModel model)
        {
            return await service.UpdateAsync(id, model).ConfigureAwait(false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id).ConfigureAwait(false);
            return NoContent();
        }

    }
}
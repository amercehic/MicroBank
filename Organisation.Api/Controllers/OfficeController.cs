using System;
using System.Threading.Tasks;
using MicroBank.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Organisation.Core.Interfaces.Service;
using Organisation.Core.Models.BindingModel;
using Organisation.Core.Models.Dto;
using Organisation.Core.Models.Filters;

namespace Organisation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService service;

        public OfficeController(IOfficeService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<OfficeDto> Get(Guid id)
        {
            return await service.GetByIdAsync(id).ConfigureAwait(false);
        }

        [HttpGet("GetByQuery")]
        public async Task<QueryResultDto<OfficeDto, Guid>> GetByQuery([FromQuery] OfficeFilter model)
        {
            return await service.GetByFilterAsync(model).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<OfficeDto> Create(OfficeCreateBindingModel model)
        {
            return await service.CreateAsync(model).ConfigureAwait(false);
        }

        [HttpPatch("{id}")]
        public async Task<OfficeDto> Update(Guid id, OfficePatchBindingModel model)
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
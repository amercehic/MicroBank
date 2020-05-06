using System;
using System.Threading.Tasks;
using Client.Core.Interfaces.Service;
using Client.Core.Models.BindingModel;
using Client.Core.Models.Dto;
using Client.Core.Models.Filters;
using MicroBank.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientApplicationController : ControllerBase
    {
        private readonly IClientApplicationService service;

        public ClientApplicationController(IClientApplicationService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ClientApplicationDto> Get(Guid id)
        {
            return await service.GetByIdAsync(id).ConfigureAwait(false);
        }

        [HttpGet("GetByQuery")]
        public async Task<QueryResultDto<ClientApplicationDto, Guid>> GetByQuery([FromQuery] ClientApplicationFilter model)
        {
            return await service.GetByFilterAsync(model).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<ClientApplicationDto> Create(ClientApplicationCreateBindingModel model)
        {
            return await service.CreateAsync(model).ConfigureAwait(false);
        }
    }
}
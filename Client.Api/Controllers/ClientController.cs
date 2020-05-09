using Client.Core.Interfaces.Service;
using Client.Core.Models.BindingModel;
using Client.Core.Models.BindingModel.ClientApplication;
using Client.Core.Models.Dto.Client;
using Client.Core.Models.Dto.ClientApplication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet("{id}")]
        public async Task<ClientDto> Get(Guid id)
        {
            return await clientService.GetByIdAsync(id).ConfigureAwait(false);
        }

        //[HttpGet("GetByQuery")]
        //public async Task<QueryResultDto<ClientDto, Guid>> GetByQuery([FromQuery] ClientFilter model)
        //{
        //    return await clientService.GetByFilterAsync(model).ConfigureAwait(false);
        //}

        [HttpPatch("GenerateClientApplication")]
        public async Task<ClientDto> GenerateClientApplication(ClientApplicationCreateBindingModel model)
        {
            return await clientService.CreateAsync(model).ConfigureAwait(false);
        }

        [HttpPatch("ApproveClientApplication/{id}")]
        public async Task<ClientDto> ApproveClientApplication(Guid id)
        {
            return await clientService.ApproveClientApplicationAsync(id).ConfigureAwait(false);
        }

        [HttpPatch("RejectClientApplication/{id}")]
        public async Task<RejectedClientApplicationDto> RejectClientApplication(Guid id, RejectedClientApplicationCreateBindingModel model)
        {
            return await clientService.RejectClientApplicationAsync(id, model).ConfigureAwait(false);
        }

        [HttpPatch("ActivateClient/{id}")]
        public async Task<ClientDto> ActivateClient(Guid id)
        {
            return await clientService.ActivateClientAsync(id).ConfigureAwait(false);
        }

    }
}
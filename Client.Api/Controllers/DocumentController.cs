using System;
using System.Threading.Tasks;
using Client.Core.Interfaces.Service;
using Client.Core.Models.BindingModel;
using Client.Core.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("{id}")]
        public async Task<DocumentDto> Get(Guid id)
        {
            return await _documentService.GetByIdAsync(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<DocumentDto> Create(DocumentCreateBindingModel model)
        {
            return await _documentService.CreateAsync(model).ConfigureAwait(false);
        }

        [HttpPatch("{id}")]
        public async Task<DocumentDto> Update(Guid id, DocumentPatchBindingModel model)
        {
            return await _documentService.UpdateAsync(id, model).ConfigureAwait(false);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _documentService.DeleteAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
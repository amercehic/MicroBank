using Client.Core.Models.BindingModel;
using Client.Core.Models.Dto;
using Client.Core.Models.Filters;
using Client.Core.Interfaces.Service;
using MicroBank.Common.Models;
using System;
using System.Threading.Tasks;
using MicroBank.Common.Repository;
using Client.Core.Entities.Client;
using MicroBank.Common.Identity;
using Client.Core.Exceptions.Client;
using Client.Core.Exceptions;

namespace Client.Core.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly ClaimsPrincipalUtil _claimsPrincipalUtil;
        private readonly IEfRepository<Document, Guid> _repository;
        private readonly IEfRepository<Core.Entities.Client.PersonalClient, Guid> _clientEfRepository;

        public DocumentService(ClaimsPrincipalUtil claimsPrincipalUtil, IEfRepository<Document, Guid> repository, IEfRepository<Core.Entities.Client.PersonalClient, Guid> clientEfRepository)
        {
            _claimsPrincipalUtil = claimsPrincipalUtil;
            _repository = repository;
            _clientEfRepository = clientEfRepository;
        }

        public async Task<DocumentDto> CreateAsync(DocumentCreateBindingModel model)
        {
            var client = await _clientEfRepository.GetByIdAsync(model.ClientId.Value).ConfigureAwait(false);

            if (client == null)
            {
                throw new ClientNotFoundException(model.ClientId.ToString());
            }

            var result = await _repository.AddAsync(new Document()
            {
                CreatedBy = _claimsPrincipalUtil.UserId,
                Url = model.DocumentUrl,
                Title = model.Title,
                Description = model.Description,
                ClientId = model.ClientId
            }).ConfigureAwait(false);

            return await GetByIdAsync(result.Id).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id).ConfigureAwait(false);

            if (entity == null)
            {
                throw new DocumentNotFoundException(id.ToString());
            }

            entity.IsDeleted = true;
            entity.UpdatedBy = _claimsPrincipalUtil.UserId;
            await _repository.UpdateAsync(entity).ConfigureAwait(false);
        }

        public async Task<DocumentDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id, s => s.Client).ConfigureAwait(false);

            if (entity == null)
            {
                throw new DocumentNotFoundException(id.ToString());
            }

            return new DocumentDto(entity);
        }

        public async Task<DocumentDto> UpdateAsync(Guid id, DocumentPatchBindingModel model)
        {
            var entity = await _repository.GetByIdAsync(id).ConfigureAwait(false);

            if (entity == null)
            {
                throw new DocumentNotFoundException(id.ToString());
            }

            entity.Title = model?.Title ?? entity.Title;
            entity.Description = model?.Description ?? entity.Description;

            entity.UpdatedBy = _claimsPrincipalUtil.UserId;
            await _repository.UpdateAsync(entity).ConfigureAwait(false);

            return await GetByIdAsync(id).ConfigureAwait(false);
        }
    }
}

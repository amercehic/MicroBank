using MicroBank.Common.Identity;
using MicroBank.Common.Models;
using MicroBank.Common.Repository;
using Microsoft.Extensions.Logging;
using Organisation.Core.Entities;
using Organisation.Core.Exceptions;
using Organisation.Core.Interfaces.Service;
using Organisation.Core.LogMessages;
using Organisation.Core.Models.BindingModel;
using Organisation.Core.Models.Dto;
using Organisation.Core.Models.Filters;
using Organisation.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organisation.Core.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly ClaimsPrincipalUtil principal;
        private readonly IEfRepository<Office, Guid> efRepository;
        private readonly ILogger<OfficeService> logger;

        public OfficeService(
            ClaimsPrincipalUtil principal, 
            IEfRepository<Office, Guid> efRepository, 
            ILogger<OfficeService> logger)
        {
            this.principal = principal;
            this.efRepository = efRepository;
            this.logger = logger;
        }

        public async Task<OfficeDto> CreateAsync(OfficeCreateBindingModel model)
        {
            logger.LogInformation(OfficeLogMessages.PerformCreatingMessage, model);

            Office office = new Office()
            {
                Name = model.Name,
                OfficeCode = model.OfficeCode,
                Openingdate = model.Openingdate,
                ParentId = model.ParentId,
                CreatedBy = principal.UserId
            };
            var returned = await efRepository.AddAsync(office).ConfigureAwait(false);
            logger.LogInformation(OfficeLogMessages.SuccessCreatingMessage, returned.Id);
            return new OfficeDto(returned);
        }

        public async Task DeleteAsync(Guid id)
        {
            logger.LogInformation(OfficeLogMessages.PerformGetByIdMessage, id.ToString());
            var entity = await efRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (entity == null)
            {
                throw new OfficeNotFoundException(id.ToString());
            }
            entity.IsDeleted = true; // soft delete
            await efRepository.UpdateAsync(entity).ConfigureAwait(false);
        }

        public async Task<QueryResultDto<OfficeDto, Guid>> GetByFilterAsync(OfficeFilter filter)
        {
            var spec = new OfficeFilterSpecifications(filter);
            (IEnumerable<Office> list, int totalCount) = await efRepository.ListAsync(spec).ConfigureAwait(false);

            return new QueryResultDto<OfficeDto, Guid>()
            {
                Items = list?.Select(s => new OfficeDto(s)),
                TotalCount = totalCount
            };
        }

        public async Task<OfficeDto> GetByIdAsync(Guid id)
        {
            logger.LogInformation(OfficeLogMessages.PerformGetByIdMessage, id);
            var entity = await efRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (entity == null)
            {
                throw new OfficeNotFoundException(id.ToString());
            }

            return new OfficeDto(entity);
        }

        public async Task<OfficeDto> UpdateAsync(Guid id, OfficePatchBindingModel model)
        {
            logger.LogInformation(OfficeLogMessages.PerformUpdatingMessage, id);
            var entity = await efRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (entity == null)
            {
                throw new OfficeNotFoundException(id.ToString());
            }

            entity.Name = model?.Name ?? entity.Name;

            await efRepository.UpdateAsync(entity).ConfigureAwait(false);

            return await GetByIdAsync(id).ConfigureAwait(false);
        }
    }
}

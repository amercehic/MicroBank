using MicroBank.Common.Identity;
using MicroBank.Common.Models;
using MicroBank.Common.Repository;
using MicroBank.EventBus.Bus;
using Microsoft.Extensions.Logging;
using Organisation.Core.Entities;
using Organisation.Core.Exceptions;
using Organisation.Core.Integrations.EventBus.Commands;
using Organisation.Core.Integrations.Services.ClientApi;
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
    public class StaffMemberService : IStaffMemberService
    {
        private readonly ClaimsPrincipalUtil _principal;
        private readonly IEfRepository<StaffMember, Guid> _efRepository;
        private readonly ILogger<StaffMemberService> _logger;
        private readonly IEfRepository<Office, Guid> _officeRepository;
        private readonly IClientApiService _clientApiService;
        private readonly IEventBus _bus;


        public StaffMemberService(
            ClaimsPrincipalUtil principal,
            IEfRepository<StaffMember, Guid> efRepository,
            ILogger<StaffMemberService> logger,
            IEfRepository<Office, Guid> officeRepository,
            IClientApiService clientApiService,
            IEventBus bus)
        {
            _principal = principal;
            _efRepository = efRepository;
            _logger = logger;
            _officeRepository = officeRepository;
            _clientApiService = clientApiService;
            _bus = bus;
        }

        public async Task<StaffMemberDto> CreateAsync(StaffMemberCreateBindingModel model)
        {
            _logger.LogInformation(StaffMemberLogMessages.PerformCreatingMessage, model);

            var office = await _officeRepository.FindByAsync(o => o.Id == model.OfficeId).ConfigureAwait(false);

            if (office == null)
            {
                throw new OfficeNotFoundException(id: model.OfficeId.ToString());
            }

            StaffMember staffMember = new StaffMember()
            {
                OfficeId = model.OfficeId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsLoanOfficer = model.IsLoanOfficer,
                MobileNumber = model.MobileNumber,
                IsActive = true,
                JoiningDate = model.JoiningDate,
                CreatedBy = _principal.UserId
            };
            var returned = await _efRepository.AddAsync(staffMember).ConfigureAwait(false);
            _logger.LogInformation(StaffMemberLogMessages.SuccessCreatingMessage, returned.Id);
            return new StaffMemberDto(returned);
        }

        public async Task DeleteAsync(Guid id)
        {
            _logger.LogInformation(StaffMemberLogMessages.PerformGetByIdMessage, id.ToString());
            var entity = await _efRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (entity == null)
            {
                throw new StaffMemberNotFoundException(id.ToString());
            }
            entity.IsDeleted = true; // soft delete
            await _efRepository.UpdateAsync(entity).ConfigureAwait(false);
        }

        public async Task<QueryResultDto<StaffMemberDto, Guid>> GetByFilterAsync(StaffMemberFilter filter)
        {
            var spec = new StaffMemberFilterSpecifications(filter);
            (IEnumerable<StaffMember> list, int totalCount) = await _efRepository.ListAsync(spec).ConfigureAwait(false);

            return new QueryResultDto<StaffMemberDto, Guid>()
            {
                Items = list?.Select(s => new StaffMemberDto(s)),
                TotalCount = totalCount
            };
        }

        public async Task<StaffMemberDto> GetByIdAsync(Guid id)
        {
            _logger.LogInformation(StaffMemberLogMessages.PerformGetByIdMessage, id);
            var entity = await _efRepository.GetByIdAsync(id, o => o.Office).ConfigureAwait(false);

            if (entity == null)
            {
                throw new StaffMemberNotFoundException(id.ToString());
            }

            return new StaffMemberDto(entity);
        }

        public async Task<StaffMemberDto> UpdateAsync(Guid id, StaffMemberPatchBindingModel model)
        {
            _logger.LogInformation(StaffMemberLogMessages.PerformUpdatingMessage, id);
            var entity = await _efRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (entity == null)
            {
                throw new OfficeNotFoundException(id.ToString());
            }

            entity.IsLoanOfficer = model?.IsLoanOfficer ?? entity.IsLoanOfficer;

            await _efRepository.UpdateAsync(entity).ConfigureAwait(false);

            var updateClientCommand = new CreateUpdateStaffMemberCommand(
                id,
                model.IsLoanOfficer
            );
            await _bus.SendCommand(updateClientCommand).ConfigureAwait(false);

            return await GetByIdAsync(id).ConfigureAwait(false);
        }
    }
}

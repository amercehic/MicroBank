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
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Core.Services
{
    public class StaffMemberService : IStaffMemberService
    {
        private readonly ClaimsPrincipalUtil principal;
        private readonly IEfRepository<StaffMember, Guid> efRepository;
        private readonly ILogger<StaffMemberService> logger;
        private readonly IEfRepository<Office, Guid> officeRepository;

        public StaffMemberService(
            ClaimsPrincipalUtil principal,
            IEfRepository<StaffMember, Guid> efRepository,
            ILogger<StaffMemberService> logger,
            IEfRepository<Office, Guid> officeRepository)
        {
            this.principal = principal;
            this.efRepository = efRepository;
            this.logger = logger;
            this.officeRepository = officeRepository;
        }

        public async Task<StaffMemberDto> CreateAsync(StaffMemberCreateBindingModel model)
        {
            logger.LogInformation(StaffMemberLogMessages.PerformCreatingMessage, model);

            var office = await officeRepository.FindByAsync(o => o.Id == model.OfficeId).ConfigureAwait(false);

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
                CreatedBy = principal.UserId
            };
            var returned = await efRepository.AddAsync(staffMember).ConfigureAwait(false);
            logger.LogInformation(StaffMemberLogMessages.SuccessCreatingMessage, returned.Id);
            return new StaffMemberDto(returned);
        }

        public async Task DeleteAsync(Guid id)
        {
            logger.LogInformation(StaffMemberLogMessages.PerformGetByIdMessage, id.ToString());
            var entity = await efRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (entity == null)
            {
                throw new StaffMemberNotFoundException(id.ToString());
            }
            entity.IsDeleted = true; // soft delete
            await efRepository.UpdateAsync(entity).ConfigureAwait(false);
        }

        public async Task<QueryResultDto<StaffMemberDto, Guid>> GetByFilterAsync(StaffMemberFilter filter)
        {
            var spec = new StaffMemberFilterSpecifications(filter);
            (IEnumerable<StaffMember> list, int totalCount) = await efRepository.ListAsync(spec).ConfigureAwait(false);

            return new QueryResultDto<StaffMemberDto, Guid>()
            {
                Items = list?.Select(s => new StaffMemberDto(s)),
                TotalCount = totalCount
            };
        }

        public async Task<StaffMemberDto> GetByIdAsync(Guid id)
        {
            logger.LogInformation(StaffMemberLogMessages.PerformGetByIdMessage, id);
            var entity = await efRepository.GetByIdAsync(id, o => o.Office).ConfigureAwait(false);

            if (entity == null)
            {
                throw new StaffMemberNotFoundException(id.ToString());
            }

            return new StaffMemberDto(entity);
        }

        public async Task<StaffMemberDto> UpdateAsync(Guid id, StaffMemberPatchBindingModel model)
        {
            logger.LogInformation(StaffMemberLogMessages.PerformUpdatingMessage, id);
            var entity = await efRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (entity == null)
            {
                throw new OfficeNotFoundException(id.ToString());
            }

            entity.IsLoanOfficer = model?.IsLoanOfficer ?? entity.IsLoanOfficer;

            await efRepository.UpdateAsync(entity).ConfigureAwait(false);

            return await GetByIdAsync(id).ConfigureAwait(false);
        }
    }
}

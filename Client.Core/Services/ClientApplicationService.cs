using Client.Core.Entities;
using Client.Core.Exceptions;
using Client.Core.Interfaces.Service;
using Client.Core.LogMessages;
using Client.Core.Models.BindingModel;
using Client.Core.Models.Dto;
using Client.Core.Models.Filters;
using Client.Core.Specifications;
using MicroBank.Common.Identity;
using MicroBank.Common.Models;
using MicroBank.Common.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Core.Services
{
    public class ClientApplicationService : IClientApplicationService
    {
        private readonly ClaimsPrincipalUtil principal;
        private readonly IEfRepository<ClientApplication, Guid> clientApplicationRepository;
        private readonly ILogger<ClientApplicationService> logger;

        public ClientApplicationService(
            ClaimsPrincipalUtil principal, 
            IEfRepository<ClientApplication, Guid> clientApplicationRepository,
            ILogger<ClientApplicationService> logger)
        {
            this.principal = principal;
            this.clientApplicationRepository = clientApplicationRepository;
            this.logger = logger;
        }

        public async Task<ClientApplicationDto> CreateAsync(ClientApplicationCreateBindingModel model)
        {
            logger.LogInformation(ClientApplicationLogMessages.PerformCreatingMessage, model);

            ClientApplication clientApplication = new ClientApplication()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                PersonalId = model.PersonalId,
                OfficeId = model.OfficeId,
                Active = model.Active,
                SubmittedOnDate = DateTime.Now,
                ClientApplicationAddressData = new ClientApplicationAddressData
                {
                    AddressLine = model.AddressLine,
                    Country = model.Country,
                    Province = model.Province,
                    Street = model.Street,
                    CountryCode = model.CountryCode
                },
                ClientApplicationFamilyDetailsData = new ClientApplicationFamilyDetailsData
                {
                    MaritalStatus = model.MaritalStatus,
                    NumberOfDependents = model.NumberOfDependents,
                    NumberOfMembers = model.NumberOfMembers,
                    NumberOfChildren = model.NumberOfChildren
                },
                ClientApplicationContactData = new ClientApplicationContactData
                {
                    EmailAddress = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber
                },
                Status = ClientApplicationStatus.Pending,
                CreatedBy = principal.UserId
            };
            var returned = await clientApplicationRepository.AddAsync(clientApplication).ConfigureAwait(false);
            logger.LogInformation(ClientApplicationLogMessages.SuccessCreatingMessage, returned.Id);

            return new ClientApplicationDto(returned);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<QueryResultDto<ClientApplicationDto, Guid>> GetByFilterAsync(ClientApplicationFilter filter)
        {
            var spec = new ClientApplicationFilterSpecifications(filter);
            (IEnumerable<ClientApplication> list, int totalCount) = await clientApplicationRepository.ListAsync(spec).ConfigureAwait(false);

            return new QueryResultDto<ClientApplicationDto, Guid>()
            {
                Items = list?.Select(s => new ClientApplicationDto(s)),
                TotalCount = totalCount
            };
        }

        public async Task<ClientApplicationDto> GetByIdAsync(Guid id)
        {
            logger.LogInformation(ClientApplicationLogMessages.PerformGetByIdMessage, id);
            var entity = await clientApplicationRepository.GetByIdAsync(id, 
                a => a.ClientApplicationAddressData,
                f => f.ClientApplicationFamilyDetailsData,
                c => c.ClientApplicationContactData).ConfigureAwait(false);

            if (entity == null)
            {
                throw new ClientApplicationNotFoundException(id.ToString());
            }

            return new ClientApplicationDto(entity);
        }

        public Task<ClientApplicationDto> UpdateAsync(Guid id, ClientApplicationPatchBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}

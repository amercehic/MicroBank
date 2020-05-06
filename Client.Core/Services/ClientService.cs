using Client.Core.Entities;
using Client.Core.Entities.Client;
using Client.Core.Exceptions;
using Client.Core.Exceptions.Client;
using Client.Core.Interfaces.Service;
using Client.Core.LogMessages;
using Client.Core.Models.BindingModel;
using Client.Core.Models.BindingModel.ClientApplication;
using Client.Core.Models.Dto.Client;
using Client.Core.Models.Dto.ClientApplication;
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
    public class ClientService : IClientService
    {
        private readonly ClaimsPrincipalUtil principal;
        private readonly IEfRepository<Entities.Client.Client, Guid> clientRepository;
        private readonly IEfRepository<Entities.ClientApplication, Guid> clientApplicationRepository;
        private readonly IEfRepository<Entities.Client.RejectedClientApplication, Guid> rejectedClientApplicationRepository;
        private readonly ILogger<ClientService> logger;

        public ClientService(
            ClaimsPrincipalUtil principal,
            IEfRepository<Entities.Client.Client, Guid> clientRepository,
            IEfRepository<Entities.ClientApplication, Guid> clientApplicationRepository,
            IEfRepository<Entities.Client.RejectedClientApplication, Guid> rejectedClientApplicationRepository,
            ILogger<ClientService> logger)
        {
            this.principal = principal;
            this.clientRepository = clientRepository;
            this.clientApplicationRepository = clientApplicationRepository;
            this.rejectedClientApplicationRepository = rejectedClientApplicationRepository;
            this.logger = logger;
        }

        public async Task<ClientDto> ApproveClientApplicationAsync(Guid id)
        {
            ClientDto clientDto = new ClientDto();
            clientDto = await CreateAsync(id).ConfigureAwait(false);
            return clientDto;
        }

        public async Task<ClientDto> CreateAsync(Guid id)
        {
            //logger.LogInformation(ClientLogMessages.PerformCreatingMessage);

            var clientApplication = await clientApplicationRepository.FindByAsync(
                o => o.Id == id, 
                c => c.ClientApplicationContactData,
                f => f.ClientApplicationFamilyDetailsData,
                a => a.ClientApplicationAddressData).ConfigureAwait(false);

            if (clientApplication == null)
            {
                throw new ClientApplicationNotFoundException(id: id.ToString());
            }

            Entities.Client.Client client = new Entities.Client.Client()
            {
                ClientApplicationId = id,
                FirstName = clientApplication.FirstName,
                LastName = clientApplication.LastName,
                DateOfBirth = clientApplication.DateOfBirth,
                PersonalId = clientApplication.PersonalId,
                OfficeId = clientApplication.OfficeId,
                Active = false,
                SubmittedOnDate = DateTime.Now,
                ClientAddressData = new ClientAddressData
                {
                    AddressLine = clientApplication.ClientApplicationAddressData.AddressLine,
                    Country = clientApplication.ClientApplicationAddressData.Country,
                    Province = clientApplication.ClientApplicationAddressData.Province,
                    Street = clientApplication.ClientApplicationAddressData.Street,
                    CountryCode = clientApplication.ClientApplicationAddressData.CountryCode
                },
                ClientFamilyDetailsData = new ClientFamilyDetailsData
                {
                    MaritalStatus = clientApplication.ClientApplicationFamilyDetailsData.MaritalStatus,
                    NumberOfDependents = clientApplication.ClientApplicationFamilyDetailsData.NumberOfDependents,
                    NumberOfMembers = clientApplication.ClientApplicationFamilyDetailsData.NumberOfMembers,
                    NumberOfChildren = clientApplication.ClientApplicationFamilyDetailsData.NumberOfChildren
                },
                ClientContactData = new ClientContactData
                {
                    EmailAddress = clientApplication.ClientApplicationContactData.EmailAddress,
                    PhoneNumber = clientApplication.ClientApplicationContactData.PhoneNumber
                },
                CreatedBy = principal.UserId
            };

            var returned = await clientRepository.AddAsync(client).ConfigureAwait(false);
            logger.LogInformation(ClientLogMessages.SuccessCreatingMessage, returned.Id);

            clientApplication.Status = ClientApplicationStatus.Approved;
            await clientApplicationRepository.UpdateAsync(clientApplication).ConfigureAwait(false);

            return new ClientDto(returned);
        }

        public async Task<QueryResultDto<ClientDto, Guid>> GetByFilterAsync(ClientFilter filter)
        {
            var spec = new ClientFilterspecifications(filter);
            (IEnumerable<Entities.Client.Client> list, int totalCount) = await clientRepository.ListAsync(spec).ConfigureAwait(false);

            return new QueryResultDto<ClientDto, Guid>()
            {
                Items = list?.Select(s => new ClientDto(s)),
                TotalCount = totalCount
            };
        }

        public async Task<ClientDto> GetByIdAsync(Guid id)
        {
            logger.LogInformation(ClientLogMessages.PerformGetByIdMessage, id);
            var entity = await clientRepository.GetByIdAsync(
                id,
                c => c.ClientContactData,
                f => f.ClientFamilyDetailsData,
                a => a.ClientAddressData).ConfigureAwait(false);

            if (entity == null)
            {
                throw new ClientNotFoundException(id.ToString());
            }

            return new ClientDto(entity);
        }

        public async Task<RejectedClientApplicationDto> RejectClientApplicationAsync(Guid id, RejectedClientApplicationCreateBindingModel model)
        {
            var clientApplication = await clientApplicationRepository.FindByAsync(
                o => o.Id == id,
                c => c.ClientApplicationContactData,
                f => f.ClientApplicationFamilyDetailsData,
                a => a.ClientApplicationAddressData).ConfigureAwait(false);

            if (clientApplication == null)
            {
                throw new ClientApplicationNotFoundException(id: id.ToString());
            }

            RejectedClientApplication entity = new RejectedClientApplication()
            {
                ClientApplicationId = id,
                Reason = model.Reason,
                Note = model.Note
            };

            clientApplication.Status = ClientApplicationStatus.Declined;
            await clientApplicationRepository.UpdateAsync(clientApplication).ConfigureAwait(false);

            return new RejectedClientApplicationDto(await rejectedClientApplicationRepository.AddAsync(entity).ConfigureAwait(false));
        }

        public Task<ClientDto> UpdateAsync(Guid id, ClientPatchBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}

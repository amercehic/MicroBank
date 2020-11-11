using Client.Core.Entities;
using Client.Core.Entities.Client;
using Client.Core.Entities.Staff;
using Client.Core.Exceptions;
using Client.Core.Exceptions.Client;
using Client.Core.Exceptions.Client.ClientApplication;
using Client.Core.Integrations.Services.OfficeApi;
using Client.Core.Integrations.Services.OfficeApi.Exceptions;
using Client.Core.Integrations.Services.OrganisationApi.Models;
using Client.Core.Interfaces.Repository;
using Client.Core.Interfaces.Service;
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
    public class PersonalClientService : IPersonalClientService
    {
        private readonly ClaimsPrincipalUtil _principal;
        private readonly IEfRepository<Entities.Client.PersonalClient, Guid> _clientEfRepository;
        private readonly IEfRepository<Entities.Client.RejectedClientApplication, Guid> _rejectedClientApplicationRepository;
        private readonly IEfRepository<Entities.Staff.StaffMember, Guid> _staffMemberEfRepository;
        private readonly ILogger<PersonalClientService> _logger;
        private readonly IOrganisationApiService _organisationApiService;
        private readonly IClientRepository _clientRepository;

        public PersonalClientService(
            ClaimsPrincipalUtil principal,
            IEfRepository<Entities.Client.PersonalClient, Guid> clientEfRepository,
            IEfRepository<Entities.Client.RejectedClientApplication, Guid> rejectedClientApplicationRepository,
            ILogger<PersonalClientService> logger,
            IOrganisationApiService organisationApiService,
            IEfRepository<Entities.Staff.StaffMember, Guid> staffMemberEfRepository,
            IClientRepository clientRepository)
        {
            _principal = principal;
            _clientEfRepository = clientEfRepository;
            _rejectedClientApplicationRepository = rejectedClientApplicationRepository;
            _logger = logger;
            _organisationApiService = organisationApiService;
            _staffMemberEfRepository = staffMemberEfRepository;
            _clientRepository = clientRepository;
        }

        public async Task<ClientDto> ApproveClientApplicationAsync(Guid id)
        {
            var client = await _clientEfRepository.FindByAsync(
                o => o.Id == id && o.Status == ClientStatus.Pending,
                c => c.ClientContactData,
                f => f.ClientFamilyDetailsData,
                a => a.ClientAddressData).ConfigureAwait(false);

            if (client == null)
            {
                throw new ClientNotFoundException(id: id.ToString());
            }

            client.Status = ClientStatus.Approved;
            client.ApprovalDateTime = DateTime.Now;

            await _clientEfRepository.UpdateAsync(client).ConfigureAwait(false);
            return await GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<RejectedClientApplicationDto> RejectClientApplicationAsync(Guid id, RejectedClientApplicationCreateBindingModel model)
        {
            var clientApplication = await _clientEfRepository.FindByAsync(
                o => o.Id == id && o.Status == ClientStatus.Pending,
                c => c.ClientContactData,
                f => f.ClientFamilyDetailsData,
                a => a.ClientAddressData).ConfigureAwait(false);

            if (clientApplication == null)
            {
                throw new ClientApplicationNotFoundException(id: id.ToString());
            }

            RejectedClientApplication entity = new RejectedClientApplication()
            {
                ClientId = id,
                Reason = model.Reason,
                Note = model.Note
            };

            clientApplication.Status = ClientStatus.Declined;
            await _clientEfRepository.UpdateAsync(clientApplication).ConfigureAwait(false);

            return new RejectedClientApplicationDto(await _rejectedClientApplicationRepository.AddAsync(entity).ConfigureAwait(false));
        }

        public async Task<ClientDto> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Get Client by id: {}", id.ToString());

            var entity = await _clientEfRepository.GetByIdAsync(id, 
                s => s.ClientAddressData, 
                s => s.ClientContactData, 
                s => s.ClientFamilyDetailsData,
                s => s.StaffMember).ConfigureAwait(false);

            if (entity == null)
            {
                throw new ClientNotFoundException(id.ToString());
            }

            return new ClientDto(entity);
        }

        public async Task<ClientDto> GenerateClientApplicationAsync(ClientApplicationCreateBindingModel model)
        {
            _logger.LogInformation("Perfom creating of Client Application: {}", model); 

            var office = await _organisationApiService.GetOfficeByIdAsync(model.OfficeId).ConfigureAwait(false);

            if (office == null)
            {
                throw new OfficeNotFoundException(id: model.OfficeId.ToString());
            }

            var existingClient = await _clientEfRepository.FindByAsync(c => c.PersonalId == model.PersonalId).ConfigureAwait(false);

            if (existingClient != null)
            {
                throw new ClientAlreadyExistException(id: model.PersonalId.ToString());
            }

            Entities.Client.PersonalClient client = new Entities.Client.PersonalClient()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                PersonalId = model.PersonalId,
                OfficeId = model.OfficeId,
                SubmittedOnDate = DateTime.Now,
                ClientAddressData = new ClientAddressData
                {
                    AddressLine = model.AddressLine,
                    Country = model.Country,
                    Province = model.Province,
                    Street = model.Street,
                    CountryCode = model.CountryCode
                },
                ClientFamilyDetailsData = new ClientFamilyDetailsData
                {
                    MaritalStatus = model.MaritalStatus,
                    NumberOfDependents = model.NumberOfDependents,
                    NumberOfMembers = model.NumberOfMembers,
                    NumberOfChildren = model.NumberOfChildren
                },
                ClientContactData = new ClientContactData
                {
                    EmailAddress = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber
                },
                CreatedBy = _principal.UserId,
                Status = ClientStatus.Pending,
                ClientType = ClientType.Personal
            };

            var returned = await _clientEfRepository.AddAsync(client).ConfigureAwait(false);
            _logger.LogInformation("Client Application successfully created with Id: {}", returned.Id);

            return new ClientDto(returned);
        }

        public async Task<ClientDto> ActivateClientAsync(Guid id)
        {
            _logger.LogInformation("Perfom activating of Client Application with id: {}", id);

            var client = await _clientEfRepository.FindByAsync(
                o => o.Id == id && o.Status == ClientStatus.Approved,
                c => c.ClientContactData,
                f => f.ClientFamilyDetailsData,
                a => a.ClientAddressData).ConfigureAwait(false);

            if (client == null)
            {
                throw new ClientNotFoundException(id: id.ToString());
            }

            client.Status = ClientStatus.Active;
            client.ActivationDateTime = DateTime.Now;

            await _clientEfRepository.UpdateAsync(client).ConfigureAwait(false);
            _logger.LogInformation("Client successfully activated with Id: {}", id);

            return await GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<ClientDto> AssignStaffMemberToClientAsync(Guid id, AssignStaffMemberBindingModel model)
        {
            _logger.LogInformation("Perfom assigning of Staff Member to Client by id: {0}, with data: {1}", id.ToString(), model);

            var client = await _clientEfRepository.FindByAsync(
                o => o.Id == id && o.Status == ClientStatus.Active,
                c => c.ClientContactData,
                f => f.ClientFamilyDetailsData,
                a => a.ClientAddressData).ConfigureAwait(false); 
            
            if (client == null)
            {
                throw new ClientNotFoundException(id: id.ToString());
            }

            var staffMember = await CreateStaffMemberIfNotExist(model.StaffMemberId).ConfigureAwait(false);
            if (client.OfficeId != staffMember.OfficeId)
            {
                throw new InvalidOfficeIdException();
            }
            client.StaffMemberId = staffMember.Id;

            await _clientEfRepository.UpdateAsync(client).ConfigureAwait(false);
            return await GetByIdAsync(client.Id).ConfigureAwait(false);
        }

        public async Task<QueryResultDto<ClientDto, Guid>> GetByFilterAsync(ClientFilter filter)
        {
            var spec = new ClientFilterspecification(filter);
            (IEnumerable<PersonalClient> list, int totalCount) = await _clientEfRepository.ListAsync(spec).ConfigureAwait(false);

            return new QueryResultDto<ClientDto, Guid>()
            {
                Items = list?.Select(s => new ClientDto(s)),
                TotalCount = totalCount
            };
        }

        public async Task<StaffMember> CreateStaffMemberIfNotExist(Guid id)
        {
            _logger.LogInformation("Perfom creating of a Staff Member with id: {}", id.ToString());

            var existingMember = await _staffMemberEfRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (existingMember != null)
            {
                return existingMember;
            }

            var newMember = await _organisationApiService.GetStaffMemberByIdAsync(id).ConfigureAwait(true);

            var entity = new StaffMember()
            {
                Id = newMember.Id,
                OfficeId = newMember.OfficeId,
                FirstName = newMember.FirstName,
                LastName = newMember.LastName,
                IsLoanOfficer = newMember.IsLoanOfficer,
                IsActive = newMember.IsActive
            };

            return await _staffMemberEfRepository.AddAsync(entity).ConfigureAwait(true);
        }

        public async Task<ClientDto> GetClientByPersonalIdAsync(string personalId)
        {
            _logger.LogInformation("Get Client by Personal ID number: {}", personalId.ToString());

            var client = await _clientEfRepository.FindByAsync(o => o.PersonalId == personalId).ConfigureAwait(false);

            if (client == null)
            {
                throw new ClientNotFoundException(personalId.ToString());
            }

            return new ClientDto(client);
        }
    }
}

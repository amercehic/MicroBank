using Client.Core.Entities.Client;
using Client.Core.Entities.Staff;
using Client.Core.Exceptions;
using Client.Core.Exceptions.Client;
using Client.Core.Integrations.Services.OfficeApi;
using Client.Core.Integrations.Services.OfficeApi.Exceptions;
using Client.Core.Integrations.Services.OrganisationApi.Models;
using Client.Core.Interfaces.Service;
using Client.Core.LogMessages;
using Client.Core.Models.BindingModel;
using Client.Core.Models.BindingModel.ClientApplication;
using Client.Core.Models.Dto.Client;
using Client.Core.Models.Dto.ClientApplication;
using Client.Core.Models.Filters;
using MicroBank.Common.Identity;
using MicroBank.Common.Models;
using MicroBank.Common.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Client.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly ClaimsPrincipalUtil _principal;
        private readonly IEfRepository<Entities.Client.Client, Guid> _clientRepository;
        private readonly IEfRepository<Entities.Client.RejectedClientApplication, Guid> _rejectedClientApplicationRepository;
        private readonly IEfRepository<Entities.Staff.StaffMember, Guid> _efStaffMemberRepository;
        private readonly ILogger<ClientService> _logger;
        private readonly IOrganisationApiService _organisationApiService;

        public ClientService(
            ClaimsPrincipalUtil principal,
            IEfRepository<Entities.Client.Client, Guid> clientRepository,
            IEfRepository<Entities.Client.RejectedClientApplication, Guid> rejectedClientApplicationRepository,
            ILogger<ClientService> logger,
            IOrganisationApiService organisationApiService,
            IEfRepository<Entities.Staff.StaffMember, Guid> efStaffMemberRepository)
        {
            _principal = principal;
            _clientRepository = clientRepository;
            _rejectedClientApplicationRepository = rejectedClientApplicationRepository;
            _logger = logger;
            _organisationApiService = organisationApiService;
            _efStaffMemberRepository = efStaffMemberRepository;
        }

        public async Task<ClientDto> ApproveClientApplicationAsync(Guid id)
        {
            var client = await _clientRepository.FindByAsync(
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

            await _clientRepository.UpdateAsync(client).ConfigureAwait(false);
            return await GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<ClientDto> CreateAsync(ClientApplicationCreateBindingModel model)
        {
            var office = await _organisationApiService.GetOfficeByIdAsync(model.OfficeId).ConfigureAwait(false);

            if (office == null)
            {
                throw new OfficeNotFoundException(id: model.OfficeId.ToString());
            }

            Entities.Client.Client client = new Entities.Client.Client()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                PersonalId = model.PersonalId,
                OfficeId = model.OfficeId,
                Active = false,
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
                Status = ClientStatus.Pending
            };

            var returned = await _clientRepository.AddAsync(client).ConfigureAwait(false);
            _logger.LogInformation(ClientLogMessages.SuccessCreatingMessage, returned.Id);

            return new ClientDto(returned);
        }

        public async Task<RejectedClientApplicationDto> RejectClientApplicationAsync(Guid id, RejectedClientApplicationCreateBindingModel model)
        {
            var clientApplication = await _clientRepository.FindByAsync(
                o => o.Id == id,
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
            await _clientRepository.UpdateAsync(clientApplication).ConfigureAwait(false);

            return new RejectedClientApplicationDto(await _rejectedClientApplicationRepository.AddAsync(entity).ConfigureAwait(false));
        }

        public async Task<ClientDto> GetByIdAsync(Guid id)
        {
            var entity = await _clientRepository.GetByIdAsync(id, 
                s => s.ClientAddressData, 
                s => s.ClientContactData, 
                s => s.ClientFamilyDetailsData).ConfigureAwait(false);

            if (entity == null)
            {
                throw new ClientNotFoundException(id.ToString());
            }

            return new ClientDto(entity);
        }

        public async Task<ClientDto> GenerateClientApplicationAsync(ClientApplicationCreateBindingModel model)
        {
            //_logger.LogInformation(ClientApplicationLogMessages.PerformCreatingMessage, model);

            Core.Entities.Client.Client clientApplication = new Core.Entities.Client.Client()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                PersonalId = model.PersonalId,
                OfficeId = model.OfficeId,
                Active = model.Active,
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
                Status = ClientStatus.Pending,
                CreatedBy = _principal.UserId
            };
            var returned = await _clientRepository.AddAsync(clientApplication).ConfigureAwait(false);
            //_logger.LogInformation(ClientApplicationLogMessages.SuccessCreatingMessage, returned.Id);

            return new ClientDto(returned);
        }

        public async Task<ClientDto> ActivateClientAsync(Guid id)
        {
            var client = await _clientRepository.FindByAsync(
                o => o.Id == id && o.Status == ClientStatus.Approved,
                c => c.ClientContactData,
                f => f.ClientFamilyDetailsData,
                a => a.ClientAddressData).ConfigureAwait(false);

            if (client == null)
            {
                throw new ClientNotFoundException(id: id.ToString());
            }

            client.Active = true;
            client.ActivationDateTime = DateTime.Now;

            await _clientRepository.UpdateAsync(client).ConfigureAwait(false);
            return await GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<ClientDto> AssignStaffMemberToClientAsync(Guid id, AssignStaffMemberBindingModel model)
        {
            var client = await _clientRepository.FindByAsync(
                o => o.Id == id && o.Status == ClientStatus.Approved && o.Active == true,
                c => c.ClientContactData,
                f => f.ClientFamilyDetailsData,
                a => a.ClientAddressData).ConfigureAwait(false); 
            
            if (client == null)
            {
                throw new ClientNotFoundException(id: id.ToString());
            }

            var staffMember = await CreateStaffMemberIfNotExist(model.StaffMemberId).ConfigureAwait(false);
            client.StaffMemberId = staffMember.Id;

            await _clientRepository.UpdateAsync(client).ConfigureAwait(false);
            return await GetByIdAsync(client.Id).ConfigureAwait(false);
        }

        public Task<QueryResultDto<ClientDto, Guid>> GetByFilterAsync(ClientFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<StaffMember> CreateStaffMemberIfNotExist(Guid id)
        {
            var existingMember = await _efStaffMemberRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (existingMember != null)
            {
                return existingMember;
            }

            var newMember = await _organisationApiService.GetStaffMemberByIdAsync(id).ConfigureAwait(true);

            var entity = new StaffMember()
            {
                Id = newMember.Id,
                OfficeId = newMember.Office.Id,
                FirstName = newMember.FirstName,
                LastName = newMember.LastName,
                IsLoanOfficer = newMember.IsLoanOfficer,
                IsActive = newMember.IsActive
            };

            return await _efStaffMemberRepository.AddAsync(entity).ConfigureAwait(true);
        }
    }
}

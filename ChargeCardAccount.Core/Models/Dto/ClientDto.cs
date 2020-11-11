using ChargeCardAccount.Core.Entities;
using MicroBank.Common.Models;
using System;

namespace ChargeCardAccount.Core.Models.Dto
{
    public class ClientDto : BaseDto<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PersonalId { get; set; }
        public Guid OfficeId { get; set; }
        public string Status { get; set; }

        public ClientDto(Client entity) : base(entity)
        {
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            DateOfBirth = entity.DateOfBirth;
            PersonalId = entity.PersonalId;
            OfficeId = entity.OfficeId.Value;
            Status = entity.Status;
        }
    }
}

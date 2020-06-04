using System;

namespace ChargeCardAccount.Core.Integrations.Services.ClientApi.Models
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PersonalId { get; set; }
        public Guid OfficeId { get; set; }
        public string Status { get; set; }
    }
}

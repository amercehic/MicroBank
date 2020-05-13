using System;

namespace Organisation.Core.Integrations.Services.ClientApi.Models
{
    public class ClientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PersonalId { get; set; }
        public Guid OfficeId { get; set; }
        public bool Active { get; set; }
    }
}

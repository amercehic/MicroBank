using System;

namespace Client.Core.Models.BindingModel
{
    public class ClientApplicationCreateBindingModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PersonalId { get; set; }
        public Guid OfficeId { get; set; }
        public string AddressLine { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public int NumberOfMembers { get; set; }
        public string MaritalStatus { get; set; }
        public int NumberOfDependents { get; set; }
        public int NumberOfChildren { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
    }
}

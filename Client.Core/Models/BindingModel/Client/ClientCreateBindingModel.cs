using System;

namespace Client.Core.Models.BindingModel
{
    public class ClientCreateBindingModel
    {
        public Guid ClientApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PersonalId { get; set; }
        public Guid OfficeId { get; set; }
        public DateTime SubmittedOnDate { get; set; }
        public ClientAddressDataCreateBindingModel ClientAddressData { get; set; }
        public ClientFamilyDetailsDataCreateBindingModel ClientFamilyDetailsData { get; set; }
        public ClientContactDataCreateBindingModel ClientContactData { get; set; }
    }
}

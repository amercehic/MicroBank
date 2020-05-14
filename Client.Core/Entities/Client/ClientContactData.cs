using System.ComponentModel.DataAnnotations;

namespace Client.Core.Entities.Client
{
    public class ClientContactData
    {
        public int Id { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }

}

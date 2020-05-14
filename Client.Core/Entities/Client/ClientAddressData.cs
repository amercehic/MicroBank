using System.ComponentModel.DataAnnotations;

namespace Client.Core.Entities.Client
{
    public class ClientAddressData
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressLine { get; set; }
        [Required]
        [StringLength(100)]
        public string Street { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(10)]
        public string CountryCode { get; set; }
        [StringLength(50)]
        public string Province { get; set; }
    }

}

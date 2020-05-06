using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Core.Entities
{
    public class ClientApplication : BaseEntity<Guid>
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(20)]
        public string PersonalId { get; set; }
        [Required]
        public Guid OfficeId { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public DateTime SubmittedOnDate { get; set; }
        public ClientApplicationAddressData ClientApplicationAddressData { get; set; }
        public ClientApplicationFamilyDetailsData ClientApplicationFamilyDetailsData { get; set; }
        public ClientApplicationContactData ClientApplicationContactData { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
    }

    public class ClientApplicationContactData
    {
        public int Id { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }

    public class ClientApplicationFamilyDetailsData
    {
        public int Id { get; set; }
        public int NumberOfMembers { get; set; }
        [Required]
        [StringLength(50)]
        public string MaritalStatus { get; set; }
        [Required]
        public int NumberOfDependents { get; set; }
        [Required]
        public int NumberOfChildren { get; set; }
    }

    public class ClientApplicationAddressData
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

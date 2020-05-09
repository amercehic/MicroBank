using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Core.Entities.Client
{
    public class Client : BaseEntity<Guid>
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
        public DateTime? ActivationDateTime { get; set; }
        public DateTime? ApprovalDateTime { get; set; }
        [Required]
        public DateTime SubmittedOnDate { get; set; }
        public ClientAddressData ClientAddressData { get; set; }
        public ClientFamilyDetailsData ClientFamilyDetailsData { get; set; }
        public ClientContactData ClientContactData { get; set; }
        public string Status { get; set; }

        #region NavProp
        //public ICollection<Entities.AccountApplication.AccountApplication> AccountApplications { get; set; }
        //public ICollection<Entities.Account.Account> Accounts { get; set; }
        #endregion
    }

    public class ClientContactData
    {
        public int Id { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }

    public class ClientFamilyDetailsData
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

using Client.Core.Entities.Staff;
using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

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
        public Core.Entities.Client.Document Document { get; set; }
        public Guid? StaffMemberId { get; set; }
        public string Status { get; set; }

        #region NavProp
        //public ICollection<Entities.AccountApplication.AccountApplication> AccountApplications { get; set; }
        //public ICollection<Entities.Account.Account> Accounts { get; set; }
        public StaffMember StaffMember { get; set; }
        #endregion
    }
}

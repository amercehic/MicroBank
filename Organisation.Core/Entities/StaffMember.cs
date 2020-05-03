using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Organisation.Core.Entities
{
    public class StaffMember : BaseEntity<Guid>
    {
        public Guid OfficeId { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        public bool IsLoanOfficer { get; set; }
        [Phone]
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoiningDate { get; set; }


        #region NavProp
        private Office Office;
        #endregion
    }
}

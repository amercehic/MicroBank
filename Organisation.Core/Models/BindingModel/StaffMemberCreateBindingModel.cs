using System;
using System.ComponentModel.DataAnnotations;

namespace Organisation.Core.Models.BindingModel
{
    public class StaffMemberCreateBindingModel
    {
        [Required]
        public Guid OfficeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool IsLoanOfficer { get; set; }
        public string MobileNumber { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Organisation.Core.Models.BindingModel
{
    public class StaffMemberPatchBindingModel
    {
        [Required]
        public bool IsLoanOfficer { get; set; }
    }
}

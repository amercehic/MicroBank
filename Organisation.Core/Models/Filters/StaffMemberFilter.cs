using MicroBank.Common.Models;

namespace Organisation.Core.Models.Filters
{
    public class StaffMemberFilter : BaseFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string OfficeName { get; set; }
    }
}

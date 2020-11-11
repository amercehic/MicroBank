using MicroBank.Common.Models;

namespace Client.Core.Models.Filters
{
    public class ClientFilter : BaseFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
    }
}

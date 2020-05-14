using MicroBank.Common.Models;

namespace Client.Core.Models.Filters
{
    public class RejectedClientApplicationFilter : BaseFilter
    {
        public string Reason { get; set; }
    }
}

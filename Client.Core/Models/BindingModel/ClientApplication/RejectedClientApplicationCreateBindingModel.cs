using System;

namespace Client.Core.Models.BindingModel.ClientApplication
{
    public class RejectedClientApplicationCreateBindingModel
    {
        public Guid ClientApplicationId { get; set; }
        public DateTime RejectionDate { get; set; } = DateTime.Now;
        public string Reason { get; set; }
        public string Note { get; set; }
    }
}

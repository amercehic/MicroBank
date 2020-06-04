using MicroBank.Common.Models;
using System;

namespace ChargeCardAccount.Core.Entities
{
    public class Balance : BaseEntity<Guid>
    {
        public int AmountId { get; set; }
        public string CreditDebitIndicator { get; set; }
        public string Type { get; set; }
        public DateTime DateOfBalance { get; set; }

        #region NavProp
        public Amount Amount { get; set; }
        #endregion NavProp
    }
}

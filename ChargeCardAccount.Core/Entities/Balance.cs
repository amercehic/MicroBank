using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChargeCardAccount.Core.Entities
{
    public class Balance : BaseEntity<Guid>
    {
        [Required]
        public Guid? AmountId { get; set; }
        public string CreditDebitIndicator { get; set; }
        public string Type { get; set; }
        public DateTime DateOfBalance { get; set; }
        [Required]
        public Guid? CreditLineId { get; set; }

        #region NavProp
        public Amount Amount { get; set; }
        public CreditLine CreditLine { get; set; }
        #endregion NavProp
    }
}

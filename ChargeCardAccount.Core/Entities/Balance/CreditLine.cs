using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChargeCardAccount.Core.Entities
{
    public class CreditLine : BaseEntity<Guid>
    {
        [Required]
        public bool Included { get; set; }
        [Required]
        public Guid? AmountId { get; set; }
        [Required]
        public string Type { get; set; }

        #region NavProp
        public Amount Amount { get; set; }
        #endregion NavProp
    }
}

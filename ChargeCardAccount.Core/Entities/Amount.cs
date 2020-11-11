using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChargeCardAccount.Core.Entities
{
    public class Amount : BaseEntity<Guid>
    {
        public decimal AmountInDecimal { get; set; }
        [Required]
        [StringLength(4)]
        public string CurrencyCode { get; set; }
    }
}

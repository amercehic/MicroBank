using MicroBank.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Card.Core.Entities
{
    
    public class Amount : BaseEntity<Guid>
    {
        public decimal AmountInDecimal { get; set; }
        [Required]
        [StringLength(4)]
        public string CurrencyCode { get; set; }
    }
}

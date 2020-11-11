using MicroBank.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Card.Core.Entities
{
    public class CreditLine : BaseEntity<Guid>
    {
        [Required]
        public bool Included { get; set; }
        public virtual Amount Amount { get; set; }
        [Required]
        public string Type { get; set; }
    }
}

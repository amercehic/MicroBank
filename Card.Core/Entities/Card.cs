using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Card.Core.Entities
{
    public class Card : BaseEntity<Guid>
    {
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string Csv { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string CardType { get; set; }
        public string Pin { get; set; }
    }
}

using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChargeCardAccount.Core.Entities
{
    public class Client : BaseEntity<Guid>
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string ClientType { get; set; }
        [Required]
        [StringLength(20)]
        public string PersonalId { get; set; }
        [Required]
        public Guid? OfficeId { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
    }
}

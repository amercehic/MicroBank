using MicroBank.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Identity.Core.Entities
{
    public class Invitation : BaseEntity<Guid>
    {
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        public Guid? UserId { get; set; } //after resolving, store here user ID
        [Required]
        public Guid ClientId { get; set; }
        [Required]
        public Guid OfficeId { get; set; }
        public string Status { get; set; }
    }

    public static class InvitationStatus
    {
        public static string Pending = "PENDING";
        public static string Resolved = "RESOLVED";
    }
}

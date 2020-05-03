using System;
using System.ComponentModel.DataAnnotations;

namespace Identity.Core.Models.BindingModel
{
    public class RegisterBindingModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        [Required]
        public string PasswordConfirm { get; set; }
        public Guid? InviteId { get; set; }
    }
}

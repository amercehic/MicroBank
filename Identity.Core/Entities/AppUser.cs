using Microsoft.AspNetCore.Identity;
using System;

namespace Identity.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public Guid? ClientId { get; set; }
    }
}

using Identity.Core.Entities;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MicroBank.Identity.Api.Services
{
    public class IdentityProfileService : IProfileService
    {
        protected UserManager<AppUser> _userManager;

        public IdentityProfileService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = _userManager.GetUserAsync(context.Subject).Result;

            var claims = new List<Claim>(await _userManager.GetClaimsAsync(user));

            context.IssuedClaims.AddRange(claims);

            await Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = _userManager.GetUserAsync(context.Subject).Result;

            context.IsActive = (user != null);

            return Task.FromResult(0);
        }

    }
}

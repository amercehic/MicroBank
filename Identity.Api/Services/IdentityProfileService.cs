using Identity.Core.Entities;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using MicroBank.Common.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
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

            if (context.Caller == IdentityServerConstants.ProfileDataCallers.UserInfoEndpoint)
            {
                context.IssuedClaims = claims;
            }
            else
            {
                // list of claims in access_token
                var allowedClaims = new string[] {
                    JwtClaimTypes.Role,
                    JwtClaimTypes.Name,
                    JwtClaimTypes.Email,
                    MicroBankIdentityConstants.ClaimTypes.ClientId,
                };

                context.IssuedClaims.AddRange(claims.Where(s => allowedClaims.Contains(s.Type)));
            }
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

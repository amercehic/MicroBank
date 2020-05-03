using Identity.Core.Entities;
using Identity.Core.Models.BindingModel;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MicroBank.Identity.Api.Services.Account
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterBindingModel registerBindingModel)
        {
            var user = new AppUser()
            {
                Email = registerBindingModel.Email,
                UserName = registerBindingModel.Email
            };
            var result = await _userManager.CreateAsync(user, registerBindingModel.Password);
            if (result.Succeeded)
            {

                // add claims
                var claimResult = await _userManager.AddClaimsAsync(user, new List<Claim>() {
                        new Claim(JwtClaimTypes.Email, registerBindingModel.Email),
                        new Claim(JwtClaimTypes.EmailVerified, "false"),
                    });


                if (!claimResult.Succeeded)
                {
                    await _userManager.DeleteAsync(user);

                    return claimResult;
                }
            }
            return result;
        }
    }
}

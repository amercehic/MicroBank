using Identity.Core.Models.BindingModel;
using MicroBank.Identity.Api.Services.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// This endpoint is for registration of Organisation admin
        /// After registration, confirmation email is sent
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<ActionResult<IdentityResult>> Register(RegisterBindingModel registerBindingModel)
        {
            return await userService.RegisterAsync(registerBindingModel).ConfigureAwait(false);
        }
    }
}
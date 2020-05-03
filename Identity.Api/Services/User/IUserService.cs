using Identity.Core.Models.BindingModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MicroBank.Identity.Api.Services.Account
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAsync(RegisterBindingModel registerBindingModel);
    }
}

using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace MicroBank.Common.Identity
{
    public class ClaimsPrincipalUtil
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsPrincipalUtil(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? UserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    userId = _httpContextAccessor.HttpContext.User.FindFirst(JwtClaimTypes.Subject)?.Value;
                }

                if (userId != null)
                {
                    return Guid.Parse(userId);
                }
                return null;
            }
        }

        public string Email
        {
            get
            {
                return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            }
        }

        public Guid? ClientId
        {
            get
            {
                var clientId = _httpContextAccessor.HttpContext.User.FindFirst(MicroBankIdentityConstants.ClaimTypes.ClientId)?.Value;
                if (clientId != null)
                {
                    return Guid.Parse(clientId);
                }
                return null;
            }
        }
    }

}

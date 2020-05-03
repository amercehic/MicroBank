using IdentityServer4.Models;
using System.Collections.Generic;
using System.Linq;

namespace MicroBank.Identity.Api.Configuration
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                //new ApiResource("Client", "Client API"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {

            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "postman",
                    ClientName = "Postman Test Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    EnableLocalLogin = true,
                    AllowedScopes = GetAllScopes(),
                    ClientSecrets = new [] {  new Secret("secret".Sha256()) },
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };

        }

        private static ICollection<string> GetAllScopes()
        {
            var scopes = new List<string>();
            scopes.AddRange(GetIdentityResources().Select(s => s.Name));
            scopes.AddRange(GetApiResources().Select(s => s.Name));
            return scopes;
        }

    }
}

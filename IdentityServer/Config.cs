using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]        {
        new Client{
        ClientId = "AccountClient",
        AllowedGrantTypes = GrantTypes.ClientCredentials,
        ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
        AllowedScopes ={ "Account"}
            }
        };
        public static IEnumerable<ApiScope> ApiScope => new ApiScope[] {
        new IdentityServer4.Models.ApiScope("Account","Account API")};
        public static IEnumerable<ApiResource> ApiResource => new ApiResource[] { };
        public static IEnumerable<IdentityResource> IdentityResource => new IdentityResource[] { };
        public static List<TestUser> TestUser => new List<TestUser> { };


    }
}

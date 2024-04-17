using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]        {
        new Client{
        ClientId = "UserServiceClient",
        AllowedGrantTypes = GrantTypes.ClientCredentials,
        ClientSecrets =
            {
                new Secret("cnytkuscu".Sha256())
            },
        AllowedScopes ={ "UserServiceScope" }
            }
        };
        public static IEnumerable<ApiScope> ApiScope => new ApiScope[] {
        new IdentityServer4.Models.ApiScope("UserServiceScope","UserService API")};
        public static IEnumerable<ApiResource> ApiResource => new ApiResource[] { };
        public static IEnumerable<IdentityResource> IdentityResource => new IdentityResource[] { };
        public static List<TestUser> TestUser => new List<TestUser> { };


    }
}

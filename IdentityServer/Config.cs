using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
          
        public static IEnumerable<IdentityResource> IdentityResource => new IdentityResource[] { };
        public static List<TestUser> TestUser => new List<TestUser> { };

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>(){
                new Client()
                {
                    ClientId = "UserServiceClient",
                    ClientName="UserService Client",
                    ClientSecrets=new[] {new Secret("cnytkuscuUserService".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes= { "UserService.Read", "UserService.Write" , "UserService.Update" }
                },
                new Client()
                {
                    ClientId = "RegisterServiceClient",
                    ClientName="RegisterService Client",
                    ClientSecrets=new[] {new Secret("cnytkuscuRegisterService".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes= { "RegisterService.Read", "RegisterService.Write", "RegisterService.Update" }
                }
            };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("UserService.Read","Read Permission for UserService"),
                new ApiScope("UserService.Write","Write & Update Permission for UserService"),
                new ApiScope("UserService.Delete","Delete Permission for UserService"),

                new ApiScope("RegisterService.Read","Read Permission for RegisterService"),
                new ApiScope("RegisterService.Write","Write & Update Permission for RegisterService"),
                new ApiScope("RegisterService.Delete","Delete Permission for RegisterService"),
            };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("UserService_Resource"){
                    Scopes={ "UserService.Read", "UserService.Write" , "UserService.Update" },
                    ApiSecrets = new []{new  Secret("cnytkuscuUserService".Sha256())}
                },
                new ApiResource("RegisterService_Resource"){
                    Scopes={ "RegisterService.Read", "RegisterService.Write", "RegisterService.Update" },
                    ApiSecrets = new []{new  Secret("cnytkuscuRegisterService".Sha256()) }
                }
            };
        }
        //public static IEnumerable<IdentityResource> GetIdentityResources()
        //{
        //    return new List<IdentityResource>()
        //    {
        //        new IdentityResources.OpenId(), //subId
        //        new IdentityResources.Profile(), ///
        //        new IdentityResource(){ Name="CountryAndCity", DisplayName="Country and City",Description="Kullanıcının ülke ve şehir bilgisi", UserClaims= new [] {"country","city"}},

        //        new IdentityResource(){ Name="Roles",DisplayName="Roles", Description="Kullanıcı rolleri", UserClaims=new [] { "role"} } //rol bazlı yetkilnedirme
        //    };
        //}








    }
}

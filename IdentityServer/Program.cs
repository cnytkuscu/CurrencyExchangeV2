namespace IdentityServer
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddIdentityServer()
                .AddInMemoryClients(Config.Clients)
                .AddInMemoryApiScopes(Config.ApiScope)
                .AddDeveloperSigningCredential();
            var app = builder.Build();
            app.UseIdentityServer();


            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}

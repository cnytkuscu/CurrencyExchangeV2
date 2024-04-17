namespace IdentityServer
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddIdentityServer()
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryApiScopes(Config.GetApiScopes())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddDeveloperSigningCredential();
            var app = builder.Build();
            app.UseIdentityServer();


            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}

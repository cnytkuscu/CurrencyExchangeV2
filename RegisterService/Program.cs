using Common;
using Common.Interfaces;
using Common.MapProfiles;
using Common.Repositories;
using Common.Services;
using Microsoft.EntityFrameworkCore;
using RegisterService.Interfaces;
using RegisterService.Repositories;
using System.Reflection;
using UserService.Interfaces;
using UserService.Repositories;

namespace RegisterService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MapProfile));
             
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService.Services.UserService>();
            builder.Services.AddScoped<IRegisterService,RegisterService.Services.RegisterService>();
            builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
            
            builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString"),
                            option =>
                            {
                                option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                            }));

            builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:7001";
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RegisterService.ReadPolicy", policy => policy.RequireClaim("scope", "RegisterService.Read"));
                options.AddPolicy("RegisterService.CreateOrUpdatePolicy", policy => policy.RequireClaim("scope", new[] { "RegisterService.Write", "RegisterService.Update" }));
                options.AddPolicy("RegisterService.DeletePolicy", policy => policy.RequireClaim("scope", "RegisterService.Delete"));
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

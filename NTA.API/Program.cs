using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NTA.Core.Repositories;
using NTA.Filters;
using NTA.Middlewares;
using NTA.Modules;
using NTA.Service.Mappings;

namespace NTA;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {

            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Token:Issuer"],
                ValidAudience = builder.Configuration["Token:Audience"],
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                ClockSkew = TimeSpan.Zero


            };
        });
        //rate limiter
        //add output cache
        //appdbcontext-appsettings

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddAutoMapper(typeof(MapProfile));
        builder.Services.AddScoped(typeof(NotFoundFilter<>));

        builder.Services.AddDbContext<AppDbContext>(x =>
        {
            x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), option =>
            {
                option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
            });
        });
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            containerBuilder.RegisterModule(new RepoServiceModule()));
        
        
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        
        app.UseCustomException();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
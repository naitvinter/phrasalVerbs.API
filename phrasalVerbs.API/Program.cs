using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PhrasalVerbs.API.Mapping;
using PhrasalVerbs.Application;
using System.Text;
using PhrasalVerbs.API.Auth;

namespace PhrasalVerbs.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration;

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["Jwt:Key"])),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidAudience = config["Jwt:Audience"],
                ValidIssuer = config["Jwt:Issuer"],
                ValidateAudience = true,
                ValidateIssuer = true
            };
        });

        builder.Services.AddAuthorization(x =>
        {
            x.AddPolicy(AuthConstants.AdminUserPolicyName, p => p.RequireClaim(AuthConstants.AdminUserClaimName, "true"));
        });

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDatabase(builder.Configuration.GetConnectionString("Default"));
        builder.Services.AddApplication();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<ValidationMappingMiddleware>();
        app.MapControllers();

        app.Run();
    }
}

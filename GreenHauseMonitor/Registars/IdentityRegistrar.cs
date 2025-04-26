
using Cmms.Core.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Cmms.Registers
{
    public class IdentityRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var authenticationSetting = new AuthenticationSettings();
            builder.Configuration.Bind(nameof(AuthenticationSettings), authenticationSetting);

            var authenticationSection = builder.Configuration.GetSection(nameof(AuthenticationSettings));
            builder.Services.Configure<AuthenticationSettings>(authenticationSection);
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;// "Bearer";
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;// "Bearer";
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//"Bearer";
            }).AddJwtBearer(cfg =>
            {
#if DEBUG
                cfg.RequireHttpsMetadata = false;
#endif
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    //ValidateActor = false,
                    ValidIssuer = authenticationSetting.JwtIssuer,
                    ValidAudiences = authenticationSetting.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authenticationSetting.JwtKey)),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = false
                };
                cfg.Audience = authenticationSetting.Audience[0];
                cfg.ClaimsIssuer = authenticationSetting.JwtIssuer;

            });
        }
    }
}
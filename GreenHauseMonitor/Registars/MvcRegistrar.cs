using Cmms.Filters;
using Cmms.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace Cmms.Registers
{
    public class MvcRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(config =>
            {
                config.Filters.Add(typeof(CmmsExceptionHandler));
            });
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();

            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<IPasswordHasher<IdentityUser>, PasswordHasher<IdentityUser>>();
            builder.Services.AddScoped<RequestTimerMiddleware>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddCors(optons =>
            {
                optons.AddPolicy("FrontEndClient", policybuilder =>
                    policybuilder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()//WithOrigins(builder.Configuration["AllowedOrgins"], builder.Configuration["AllowedOrginsWeb"])//todoo
                );
            });
        }
    }
}

using Cmms.Authorization;
using Cmms.Models.Validators;
using Cmms.Models;
using Cmms.Services;
using Cmms;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Reflection;
using Cmms.EntitieDbCOntext;
using Cmms.Entities;
using Cmms.Middleware;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.ComponentModel.DataAnnotations;
using Cmms.Controllers;


var builder = WebApplication.CreateBuilder();

// NLog: Setup Nlog for Dependency injection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

//configure services
//builder.Services.AddIdentity<User, Role>(options =>
//{
//    options.Password.RequiredLength = 3;
//    //options.Password.RequireNonAlphanumeric = true;
//    //options.Password.RequireDigit = true;
//    //options.Password.RequireLowercase = true;
//    //options.Password.RequireUppercase = true;
//});//.add. AddEntityFrameworkStores<AuthCmmsDbContext>()
////.AddDefaultTopkenProviders();

var authenticationSetting = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSetting);
builder.Services.AddSingleton(authenticationSetting);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;// "Bearer";
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;// "Bearer";
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//"Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateActor = false,
        ValidIssuer = authenticationSetting.JwtIssuer,
        ValidAudience = authenticationSetting.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSetting.JwtKey)),
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        RequireExpirationTime = true
    };

});
builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("SettingAllowedOperation", builder => builder.AddRequirements(new SettingAllowedOperation(string.)));
    options.AddPolicy("HasNationality", builder => builder.RequireClaim("Nationality", "German", "Polish", "string"));
    options.AddPolicy("AtLeast18", builder => builder.AddRequirements(new MinimumAgeRequirement(18)));
});
AddAuthorizationHandlers(builder.Services);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GreenHauseMonitor", Version = "v1" });
});
// services.AddControllers().AddFluentValidation();//obselite (stare)
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddDbContext<CmmsDbContext>();
builder.Services.AddScoped<CmmSSeeder>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<IQuestService, QuestService>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IEquipmentSetService, EquipmentSetService>();
builder.Services.AddScoped<IOccurrenceService, OccurrenceService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidators>();
builder.Services.AddScoped<IValidator<RestaurantQuery>, CmmsQueryValidator>();
builder.Services.AddScoped<RequestTimerMiddleware>();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(optons =>
{
    optons.AddPolicy("FrontEndClient", policybuilder =>
        policybuilder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()//WithOrigins(builder.Configuration["AllowedOrgins"], builder.Configuration["AllowedOrginsWeb"])//todoo
    );
});

//configure
var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<CmmSSeeder>();
app.UseResponseCaching();
app.UseStaticFiles();
app.UseCors("FrontEndClient");
seeder.Seed();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GreenHauseMonitor v1"));
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimerMiddleware>();
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

void AddAuthorizationHandlers(IServiceCollection services) 
{
    services.AddScoped<IAuthorizationHandler, SettingAllowedOperationHandler>();
    services.AddScoped<IAuthorizationHandler, ResourcesOperationRequirementHandler>();
    services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
}

//namespace GreenHauseMonitor
//{
//    public class Program
//    {

//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                })
//                .UseNLog();
//    }
//}

//Lubie placki


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Cmms.Registers;


var builder = WebApplication.CreateBuilder();


builder.RegisterServices(typeof(Program));

var app = builder.Build();

app.RegisterPipelineComponents(typeof(Program));

app.Run();

//Lubie placki

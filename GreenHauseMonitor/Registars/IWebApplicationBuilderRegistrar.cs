using Microsoft.AspNetCore.Builder;

namespace Cmms.Registers
{
    public interface IWebApplicationBuilderRegistrar : IRegistrar
    {
        void RegisterServices(WebApplicationBuilder builder);
    }
}

using Microsoft.AspNetCore.Builder;

namespace Cmms.Registers
{
    public interface IWebApplicationRegistrar : IRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app);
    }
}

using Cmms.Core.DtoModels;
using Cmms.Core.Models;
using MediatR;

namespace Cmms.Core.Commands.IdentityCommands
{
    public class LoginCommand : IRequest<OperationResult<IdentityUserProfileDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

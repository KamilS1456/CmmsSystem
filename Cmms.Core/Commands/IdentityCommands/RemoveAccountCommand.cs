using Cmms.Core.Models;
using MediatR;

namespace Cmms.Core.Commands.IdentityCommands
{
    public class RemoveAccountCommand : IRequest<OperationResult<bool>>
    {
        public Guid IdentityUserIdToDelete { get; set; }

        public Guid UserProfileIdRequestingDelete { get; set; }
    }
}

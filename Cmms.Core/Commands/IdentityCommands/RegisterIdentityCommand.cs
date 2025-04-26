using Cmms.Core.DtoModels;
using Cmms.Core.Models;
using MediatR;

namespace Cmms.Core.Commands.IdentityCommands
{
    public class RegisterIdentityCommand : IRequest<OperationResult<IdentityUserProfileDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CurrentCity { get; set; }
    }
}

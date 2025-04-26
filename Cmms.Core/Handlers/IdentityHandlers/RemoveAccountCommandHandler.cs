using Cmms.Core.Commands.IdentityCommands;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Handlers.IdentityHandlers
{
    public class RemoveAccountCommandHandler : IRequestHandler<RemoveAccountCommand, OperationResult<bool>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public RemoveAccountCommandHandler(CmmsDbContext cmmsDbContext) 
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<OperationResult<bool>> Handle(RemoveAccountCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<bool>();

            try
            {
                var identityUser = await _cmmsDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.IdentityUserIdToDelete.ToString(), cancellationToken);

                if (identityUser is null) {
                    result.AddError(Enums.ErrorCode.IdentityUserDoesNotExist, "Unable to find a user with the specified Id");
                    return result;
                }

                var userProfile = await _cmmsDbContext.UserProfileS.FirstOrDefaultAsync( up => up.IdentityId == request.IdentityUserIdToDelete.ToString(), cancellationToken);

                if (userProfile is null)
                {
                    result.AddError(Enums.ErrorCode.IdentityUserDoesNotExist, "Unable to find a user profile with the specified Id");
                    return result;
                }

                if (request.UserProfileIdRequestingDelete != request.IdentityUserIdToDelete) {
                    result.AddError(Enums.ErrorCode.UserNotPermitedForAction, "User not permited to delete");
                    return result;
                }

                _cmmsDbContext.UserProfileS.Remove(userProfile);
                _cmmsDbContext.Users.Remove(identityUser);
                await _cmmsDbContext.SaveChangesAsync(cancellationToken);

                result.Payload = true;
            }
            catch (Exception ex)
            {
                result.AddUnknownError(ex.Message);
            }
            return result;
        }
    }
}

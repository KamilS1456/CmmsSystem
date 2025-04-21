using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Core.Enums;
using Cmms.Core.Models;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities;
using Cmms.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Handlers.UserProfileHandlers.UserProfileCommandHandlers
{
    class DeleteQuestCommandHandler : IRequestHandler<DeleteUserProfileCommand, OperationResult<UserProfile>>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public DeleteQuestCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<OperationResult<UserProfile>> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            try
            {
                var userProfile = await _cmmsDbContext.UserProfileS.FirstOrDefaultAsync(f => f.UserProfileId == request.UserProfileId);
                result.Payload = userProfile;
                if (userProfile is null)
                {
                    result.AddError(ErrorCode.NotFound, string.Format("No UserProfile found for ID {0}", request.UserProfileId));
                }
                else
                {
                    _cmmsDbContext.UserProfileS.Remove(userProfile);
                    await _cmmsDbContext.SaveChangesAsync();
                }
            } catch (UserProfileNotValidException ex){
                ex.ValidationErrors.ForEach(e => result.AddError(ErrorCode.ValidationError, e));
            } catch (Exception e){
                result.AddUnknownError(e.Message);
            }

            return result;
        }
    }
}

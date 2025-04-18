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
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, OperationResult<UserProfile>>
    {
        private readonly CmmsDbContext _cmmsDbContext; 

        public UpdateUserProfileCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }

        public async Task<OperationResult<UserProfile>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            try
            {
                var userProfile = await _cmmsDbContext.UserProfileS.FirstOrDefaultAsync(x => x.UserProfileId == request.UserProfileId);

                if (userProfile is null)
                {
                    result.AddError(ErrorCode.NotFound, string.Format("No UserProfile found for ID {0}", request.UserProfileId));
                    return result;
                }
                var basicInfo = UserProfileBasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress,
                    request.Phone, request.DateOfBirth, request.CurrentCity);

                userProfile.UpdateBasicInfo(basicInfo);

                _cmmsDbContext.UserProfileS.Update(userProfile);
                await _cmmsDbContext.SaveChangesAsync(cancellationToken);

                result.Payload = userProfile;

                return result;
            } catch (UserProfileNotValidException ex){
                ex.ValidationErrors.ForEach(e => result.AddError(ErrorCode.ValidationError, e));
            } catch (Exception e){
                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}

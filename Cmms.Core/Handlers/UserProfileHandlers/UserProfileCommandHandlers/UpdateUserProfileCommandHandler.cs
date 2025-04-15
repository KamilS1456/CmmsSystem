using Cmms.Core.Commands.UserProfileCommands;
using Cmms.DataAccess.EntitieDbCOntext;
using Cmms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.Handlers.UserProfileHandlers.UserProfileCommandHandlers
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand>
    {
        private readonly CmmsDbContext _cmmsDbContext; 

        public UpdateUserProfileCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }

        public async Task Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await  _cmmsDbContext.UserProfileS.FirstOrDefaultAsync(x => x.UserProfileId == request.UserProfileId);

            var basicInfo = UserProfileBasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress,
                request.Phone, request.DateOfBirth, request.CurrentCity);
            userProfile.UpdateBasicInfo(basicInfo);
            _cmmsDbContext.UserProfileS.Update(userProfile);
            await _cmmsDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

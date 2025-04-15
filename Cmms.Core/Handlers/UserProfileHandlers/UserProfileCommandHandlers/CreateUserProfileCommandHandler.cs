using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Domain.Entities;
using Cmms.Core.Respones.UserProfileResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmms.DataAccess.EntitieDbCOntext;
using AutoMapper;

namespace Cmms.Core.Handlers.UserProfileHandlers.UserProfileCommandHandlers
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfile>
    {
        private readonly CmmsDbContext _cmmsDbContext;
        public CreateUserProfileCommandHandler(CmmsDbContext cmmsDbContext)
        {
            _cmmsDbContext = cmmsDbContext;
        }
        public async Task<UserProfile> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var basicInfo = UserProfileBasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress,
                request.Phone, request.DateOfBirth, request.CurrentCity);
            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);

            _cmmsDbContext.UserProfileS.Add(userProfile);
            await _cmmsDbContext.SaveChangesAsync(cancellationToken);
            return userProfile;

        }
    }
}

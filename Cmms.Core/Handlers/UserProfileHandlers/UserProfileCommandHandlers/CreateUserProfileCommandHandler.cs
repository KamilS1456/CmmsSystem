using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Domain.Entities;
using MediatR;
using Cmms.DataAccess.EntitieDbCOntext;

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

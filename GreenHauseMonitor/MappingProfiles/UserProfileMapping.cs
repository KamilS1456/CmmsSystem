using AutoMapper;
using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Requests.UserProfileRequests;
using Cmms.Respones.UserProfileResponse;
using Cmms.Domain.Entities;

namespace Cmms.MappingProfiles
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<UserProfileBasicInfo, UserProfileBasicInfoResponse>();
            CreateMap<UserProfileUpdate, UpdateUserProfileCommand>();
        }
    }
}

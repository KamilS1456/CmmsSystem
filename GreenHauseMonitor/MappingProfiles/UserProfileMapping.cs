using AutoMapper;
using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Core.Requests.UserProfileRequests;
using Cmms.Core.Respones.UserProfileResponse;
using Cmms.Domain.Entities;

namespace Cmms.MappingProfiles
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<UserProfileCreate, CreateUserProfileCommand>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<UserProfileBasicInfo, UserProfileBasicInfoResponse>();
            CreateMap<UserProfileUpdate, UpdateUserProfileCommand>();
        }
    }
}

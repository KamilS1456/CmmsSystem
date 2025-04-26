using AutoMapper;
using Cmms.Core.Commands.IdentityCommands;
using Cmms.Core.DtoModels;
using Cmms.Domain.Entities;
using Cmms.Requests.Identity;
using Cmms.Respones.IdentityResponse;

namespace Cmms.MappingProfiles
{
    public class IdentityMapping : Profile
    {
        public IdentityMapping()
        {
            CreateMap<UserRegistration, RegisterIdentityCommand>();
            CreateMap<Login, LoginCommand>();
            CreateMap<IdentityUserProfileDto, IdentityUserProfile>();
            CreateMap<UserProfile, IdentityUserProfileDto>()
            .ForMember(dest => dest.Phone, opt
            => opt.MapFrom(src => src.UserProfileBasicInfo.Phone))
            .ForMember(dest => dest.CurrentCity, opt
            => opt.MapFrom(src => src.UserProfileBasicInfo.CurrentCity))
            .ForMember(dest => dest.EmailAddress, opt
            => opt.MapFrom(src => src.UserProfileBasicInfo.EmailAddress))
            .ForMember(dest => dest.FirstName, opt
            => opt.MapFrom(src => src.UserProfileBasicInfo.FirstName))
            .ForMember(dest => dest.LastName, opt
            => opt.MapFrom(src => src.UserProfileBasicInfo.LastName))
            .ForMember(dest => dest.DateOfBirth, opt
            => opt.MapFrom(src => src.UserProfileBasicInfo.DateOfBirth));
        }
    }
}

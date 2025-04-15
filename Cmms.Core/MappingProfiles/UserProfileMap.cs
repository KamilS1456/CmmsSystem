using AutoMapper;
using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Core.MappingProfiles
{
    internal class UserProfileMap : Profile
    {
        public UserProfileMap()
        {
            CreateMap<CreateUserProfileCommand, UserProfileBasicInfo>();
        }
    }
}

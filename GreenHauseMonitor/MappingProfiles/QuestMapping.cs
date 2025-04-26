using AutoMapper;
using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Requests.Quest;
using Cmms.Domain.Entities.Quest;
using Cmms.Respones.QuestResponse;
using Cmms.Core.Commands.QuestCommands;
using Cmms.DtoModels;
using System.Collections.Generic;

namespace Cmms.MappingProfiles
{
    public class QuestMapping : Profile
    {
        public QuestMapping()
        {
            CreateMap<QuestCreate, CreateQuestCommand>();
            CreateMap<Quest, QuestResponse>();
            CreateMap<QuestUpdate, UpdateQuestCommand>();
            CreateMap<QuestToUser, QuestToUserDto>().ReverseMap();
            CreateMap<QuestToEquipment, QuestToEquipmentDto>().ReverseMap();
        }
    }
}

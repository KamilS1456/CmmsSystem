using AutoMapper;
using Cmms.Domain.Entities;
using Cmms.Requests.QuestType;
using Cmms.Respones.QuestTypeResponse;
using Cmms.Core.Commands.QuestTypeCommand;
using Cmms.Core.Commands.QuestCommands;

namespace Cmms.MappingProfiles
{
    public class QuestTypeMapping : Profile
    {
        public QuestTypeMapping()
        {
            CreateMap<QuestTypeCreate, CreateQuestTypeCommand>();
            CreateMap<QuestType, QuestTypeResponse>();
            CreateMap<QuestTypeUpdate, UpdateQuestTypeCommand>();
        }
    }
}

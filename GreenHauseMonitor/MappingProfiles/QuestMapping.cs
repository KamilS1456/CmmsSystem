using AutoMapper;
using Cmms.Core.Commands.UserProfileCommands;
using Cmms.Requests.Quest;
using Cmms.Domain.Entities.Quest;
using Cmms.Respones.QuestResponse;
using Cmms.Core.Commands.QuestCommands;

namespace Cmms.MappingProfiles
{
    public class QuestMapping : Profile
    {
        public QuestMapping()
        {
            CreateMap<QuestCreate, CreateQuestCommand>();
            CreateMap<Quest, QuestResponse>();
            CreateMap<QuestUpdate, UpdateQuestCommand>();
        }
    }
}

using Cmms.Core.Models;
using Cmms.Domain.Dictionary;
using Cmms.Domain.Entities;
using Cmms.Domain.Entities.Quest;
using MediatR;
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Core.Commands.QuestCommands
{
    public class CreateQuestCommand : IRequest<OperationResult<Quest>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLineDataTime { get; set; }
        public int Priority { get; set; }
        public QuestState QuestState { get; set; } = QuestState.New;
        public Guid QuestTypeId { get; set; }
    }
}

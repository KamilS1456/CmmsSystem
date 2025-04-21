using Cmms.Core.Models;
using Cmms.Domain.Dictionary;
using Cmms.Domain.Entities;
using Cmms.Domain.Entities.Quest;
using MediatR;
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Core.Commands.QuestTypeCommand
{
    public class CreateQuestTypeCommand : IRequest<OperationResult<QuestType>>
    {
        public string Name { get; set; }
        public int DefaultPriority { get; set; }
    }
}

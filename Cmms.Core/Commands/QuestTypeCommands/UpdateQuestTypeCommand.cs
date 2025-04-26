using Cmms.Core.Models;
using Cmms.Domain.Entities.Quest;
using MediatR;

namespace Cmms.Core.Commands.QuestTypeCommand
{
    public class UpdateQuestTypeCommand : IRequest<OperationResult<QuestType>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DefaultPriority { get; set; } = 1;
    }
}

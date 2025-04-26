using Cmms.Core.Models;
using Cmms.Domain.Entities.Quest;
using MediatR;

namespace Cmms.Core.Commands.QuestTypeCommand
{
    public class CreateQuestTypeCommand : IRequest<OperationResult<QuestType>>
    {
        public Guid CreatedByUserID { get; set; }
        public string Name { get; set; }
        public int DefaultPriority { get; set; }
    }
}

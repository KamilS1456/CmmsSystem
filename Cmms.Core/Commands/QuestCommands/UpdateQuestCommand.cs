using Cmms.Core.Models;
using Cmms.Domain.Entities.Quest;
using Cmms.DtoModels;
using MediatR;
using static Cmms.Domain.Dictionary.QuestStateEnum;

namespace Cmms.Core.Commands.QuestCommands
{
    public class UpdateQuestCommand : IRequest<OperationResult<Quest>>
    {
        public Guid UpdateByUserID { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLineDataTime { get; set; }
        public int Priority { get; set; }
        public QuestState QuestState { get; set; }
        public Guid QuestTypeId { get; set; }

        public IEnumerable<QuestToUserDto> QuestToUsers { get; set; }
        public IEnumerable<QuestToEquipmentDto> QuestToEquipments { get; set; }
    }
}

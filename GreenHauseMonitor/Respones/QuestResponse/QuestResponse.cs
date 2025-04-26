using Cmms.DtoModels;
using System;
using System.Collections.Generic;
using static Cmms.Domain.Dictionary.QuestStateEnum;

namespace Cmms.Respones.QuestResponse
{
    public class QuestResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLineDataTime { get; set; }
        public int Priority { get; set; }
        public QuestState QuestState { get; set; }
        public Guid QuestTypeId { get; set; }

        IEnumerable<QuestToUserDto> QuestToUsers { get; set; }
        IEnumerable<QuestToEquipmentDto> QuestToEquipments { get; set; }
    }
}

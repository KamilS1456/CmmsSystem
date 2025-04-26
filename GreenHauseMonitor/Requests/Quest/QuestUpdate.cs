using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Cmms.DtoModels;
using static Cmms.Domain.Dictionary.QuestStateEnum;

namespace Cmms.Requests.Quest
{
    public class QuestUpdate
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLineDataTime { get; set; }
        public int Priority { get; set; }
        public QuestState QuestState { get; set; }

        [Required]
        public Guid QuestTypeId { get; set; }

        public IEnumerable<QuestToUserDto> QuestToUsers { get; set; }
        public IEnumerable<QuestToEquipmentDto> QuestToEquipments { get; set; }
    }
}

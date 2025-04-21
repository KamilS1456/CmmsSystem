using Cmms.Domain.Dictionary;
using static Cmms.Domain.Dictionary.Dictionary;
using System;
using System.ComponentModel.DataAnnotations;
using Cmms.Filters;

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
        public QuestState QuestState { get; set; } = QuestState.New;

        [Required]
        public Guid QuestTypeId { get; set; }
    }
}

using Cmms.Domain.Dictionary;
using static Cmms.Domain.Dictionary.Dictionary;
using System;

namespace Cmms.Respones.QuestResponse
{
    public class QuestInfoResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLineDataTime { get; set; }
        public int Priority { get; set; }
        public QuestState QuestState { get; set; } = QuestState.New;
        public Guid QuestTypeId { get; set; }
    }
}

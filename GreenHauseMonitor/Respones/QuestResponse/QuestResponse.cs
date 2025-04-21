using Cmms.Domain.Dictionary;
using Cmms.Respones.UserProfileResponse;
using System;
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Respones.QuestResponse
{
    public class QuestResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLineDataTime { get; set; }
        public int Priority { get; set; }
        public QuestState QuestState { get; set; } = QuestState.New;
        public Guid QuestTypeId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Domain.Entities
{
    public class Quest : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLineDataTime { get; set; }
        public int Priority { get; set; }     
        public QuestState QuestState { get; set; } = QuestState.New;
        public int QuestTypeId { get; set; }


        public virtual QuestType QuestType { get; set; }
        public virtual List<QuestToUser> QuestToUserList {  get; set; }
        public virtual List<QuestToEquipment> QuestToEquipmentList { get; set; }




    }
}

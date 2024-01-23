using System;
using System.Collections.Generic;

namespace Cmms.Entities
{
    public class Quest : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLineDataTime { get; set; }
        public int Priority { get; set; }       
        public virtual List<QuestToUser> QuestToUserList {  get; set; }
        public virtual List<QuestToEquipment> QuestToEquipmentList { get; set; }


    }
}

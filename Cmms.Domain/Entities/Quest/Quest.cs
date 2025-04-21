using System;
using System.Collections.Generic;
using System.Xml.Linq;
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Domain.Entities.Quest
{
    public class Quest : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DeadLineDataTime { get; private set; }
        public int Priority { get; private set; }     
        public QuestState QuestState { get; private set; } = QuestState.New;
        public Guid QuestTypeId { get; private set; }


        public virtual QuestType QuestType { get; set; }
        public virtual List<QuestToUser> QuestToUserList {  get; set; }
        public virtual List<QuestToEquipment> QuestToEquipmentList { get; set; }

        // Factory method
        public static Quest CreateQuest(Guid userProfileID, string name, string description, Guid questTypeID,
            int priority, QuestState questState, DateTime deadLineDataTime, 
            List<QuestToUser> questToUsers, List<QuestToEquipment> QuestToEquipmentList)
        {
            //var validator = new QuestValidator();
            return new Quest
            {
               // LastModifyByUserId = userProfileID,
                //CreatedByUserId = userProfileID,
                CreationDateTime = DateTime.UtcNow,
                LastModifyDateTime = DateTime.UtcNow,
                Name = name,
                Description = description,
                QuestTypeId = questTypeID,
                Priority = priority,
                QuestState = questState,
                DeadLineDataTime = deadLineDataTime
            };
            //List<QuestToUser> questToUsers, List< QuestToEquipment > QuestToEquipmentList todoo
        }

        //public methods

        public void UpdateQuest(Guid userProfileID, string name, string description, Guid questTypeID,
            int priority, QuestState questState, DateTime deadLineDataTime,
            List<QuestToUser> questToUsers, List<QuestToEquipment> QuestToEquipmentList)
        {
            //LastModifyByUserId = userProfileID;
            LastModifyDateTime = DateTime.UtcNow;
            Name = name;
            Description = description;
            QuestTypeId = questTypeID;
            Priority = priority;
            QuestState = questState;
            DeadLineDataTime = deadLineDataTime;
        }




    }
}

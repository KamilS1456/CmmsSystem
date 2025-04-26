using Cmms.Domain.Exceptions;
using Cmms.Domain.Validators.QuestValidators;
using static Cmms.Domain.Dictionary.QuestStateEnum;

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
            int priority, QuestState questState, DateTime deadLineDataTime
            , IEnumerable<QuestToUser> usersForQuest, IEnumerable<QuestToEquipment> equipmentsForQuest)
        {
            var validator = new QuestValidator();
            var quest =  new Quest
            {
                LastModifyByUserId = userProfileID,
                CreatedByUserId = userProfileID,
                CreationDateTime = DateTime.UtcNow,
                LastModifyDateTime = DateTime.UtcNow,
                Name = name,
                Description = description,
                QuestTypeId = questTypeID,
                Priority = priority,
                QuestState = questState,
                DeadLineDataTime = deadLineDataTime,
            };
            quest.UpdatedQuestToUserList(usersForQuest);
            quest.UpdatedQuestToEquipmentList(equipmentsForQuest);

            var validationResult = validator.Validate(quest);         

            if (validationResult.IsValid) {
                return quest;
            }

            var exception = new QuestNotValidException("The quest is not valid");
            foreach (var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }
            throw exception;

        }

        //public methods

        public void UpdateQuest(Guid userProfileID, string name, string description, Guid questTypeID,
            int priority, QuestState questState, DateTime deadLineDataTime, IEnumerable<QuestToUser> questToUser, IEnumerable<QuestToEquipment> questToEquipment)
        {
            LastModifyByUserId = userProfileID;
            LastModifyDateTime = DateTime.UtcNow;
            Name = name;
            Description = description;
            QuestTypeId = questTypeID;
            Priority = priority;
            QuestState = questState;
            DeadLineDataTime = deadLineDataTime;

            UpdatedQuestToUserList(questToUser);
            UpdatedQuestToEquipmentList(questToEquipment);

            var validator = new QuestValidator();
            var validationResult = validator.Validate(this);

            if (!validationResult.IsValid)
            {
                var exception = new QuestNotValidException("The quest is not valid");
                foreach (var error in validationResult.Errors)
                {
                    exception.ValidationErrors.Add(error.ErrorMessage);
                }
                throw exception;
            }

            
        }

        void UpdatedQuestToUserList(IEnumerable<QuestToUser> questToUser)
        {
            var updatedQuestToUserList = new List<QuestToUser>();
            foreach (var qtu in questToUser)
            {                
               updatedQuestToUserList.Add(QuestToUser.CreateQuestToUser(Id, qtu.UserId, qtu.UserInQuestResponsability));                
            }
            QuestToUserList = updatedQuestToUserList;
        }

        void UpdatedQuestToEquipmentList(IEnumerable<QuestToEquipment> questToEquipment)
        {
            var updatedQuestToEquipmentList = new List<QuestToEquipment>();
            foreach (var qte in questToEquipment)
            {
                updatedQuestToEquipmentList.Add(QuestToEquipment.CreateQuestToEquipment(Id, qte.EquipmentId));
            }
            QuestToEquipmentList = updatedQuestToEquipmentList;
        }
    }
}

using Cmms.Domain.Exceptions;
using Cmms.Domain.Validators.QuestTypeValidators;
using Cmms.Domain.Validators.QuestValidators;

namespace Cmms.Domain.Entities.Quest
{
    public class QuestType : EntityBase
    {
        public string Name { get; private set; }
        public int DefaultPriority { get; private set; } = 1;

    

     // Factory method
        public static QuestType CreateQuestType(Guid userProfileID, string name, int defaultpriority)
        {
            var questType =  new QuestType
            {
                LastModifyByUserId = userProfileID,
                CreatedByUserId = userProfileID,
                CreationDateTime = DateTime.UtcNow,
                LastModifyDateTime = DateTime.UtcNow,
                Name = name,
                DefaultPriority = defaultpriority
            };
            var validationResult = new QuestTypeValidator().Validate(questType);

            if (validationResult.IsValid)
            {
                return questType;
            }
            var exception = new QuestNotValidException("The quest is not valid");
            foreach (var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }
            throw exception;
        }

        //public methods

        public void UpdateQuestType(string name, int defaultpriority)
        {
            Name = name;
            DefaultPriority = defaultpriority;
            LastModifyDateTime = DateTime.UtcNow;

            var validator = new QuestTypeValidator();
            var validationResult = validator.Validate(this);

            if (!validationResult.IsValid)
            {
                var exception = new QuestNotValidException("The quest type is not valid");
                foreach (var error in validationResult.Errors)
                {
                    exception.ValidationErrors.Add(error.ErrorMessage);
                }
                throw exception;
            }
        }
    }
}

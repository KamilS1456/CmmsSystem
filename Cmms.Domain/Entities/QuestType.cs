namespace Cmms.Domain.Entities
{
    public class QuestType : EntityBase
    {
        public string Name { get; private set; }
        public int DefaultPriority { get; private set; } = 1;

    

     // Factory method
        public static QuestType CreateQuestType(string name, int defaultpriority)
        {
            return new QuestType
            {
                Name = name,
                DefaultPriority = defaultpriority
            };
        }

        //public methods

        public void UpdateQuestType(string name, int defaultpriority)
        {
            Name = name;
            DefaultPriority = defaultpriority;
            LastModifyDateTime = DateTime.UtcNow;
        }
    }
}

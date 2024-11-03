namespace Cmms.Entities
{
    public class QuestType : EntityBase
    {
        public string Name { get; set; }
        public int DefaultPriority { get; set; } = 1;

    }
}

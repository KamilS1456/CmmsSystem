namespace Cmms.Entities
{
    public class OccurrenceType : EntityBase
    {
        public string Name { get; set; }
        public int DefaultPriority { get; set; } = 1;
    }
}

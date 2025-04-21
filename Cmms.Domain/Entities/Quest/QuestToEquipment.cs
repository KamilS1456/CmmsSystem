namespace Cmms.Domain.Entities.Quest
{
    public class QuestToEquipment
    {
        public Guid Id { get; private set; }
        public Guid QuestId { get; private set; }
        public Guid EquipmentId { get; private set; }
    }
}

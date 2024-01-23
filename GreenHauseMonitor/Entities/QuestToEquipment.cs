namespace Cmms.Entities
{
    public class QuestToEquipment
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int EquipmentId { get; set; }

        public virtual Quest Quest { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}

namespace Cmms.Domain.Entities
{
    public class EquipmentSetToEquipment
    {
        public int Id { get; set; }
        public int EquipmentSetID { get; set; }
        public int EquipmentID { get; set; }

        public virtual EquipmentSet EquipmentSet { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}

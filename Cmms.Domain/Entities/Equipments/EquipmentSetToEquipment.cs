using Cmms.Domain.Entities.Equipments;

namespace Cmms.Domain.Entities.Equipments
{
    public class EquipmentSetToEquipment
    {
        public Guid Id { get; set; }
        public Guid EquipmentSetID { get; set; }
        public Guid EquipmentID { get; set; }

        public virtual EquipmentSet EquipmentSet { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}

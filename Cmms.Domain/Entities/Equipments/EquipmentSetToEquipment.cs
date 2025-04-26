
namespace Cmms.Domain.Entities.Equipments
{
    public class EquipmentSetToEquipment
    {
        public Guid Id { get; private set; }
        public Guid EquipmentSetID { get; private set; }
        public Guid EquipmentID { get; private set; }

        public virtual EquipmentSet EquipmentSet { get; private set; }
        public virtual Equipment Equipment { get; private set; }


        public static EquipmentSetToEquipment CreateEquipmentSetToEquipment(Guid equipmentSetId, Guid equipmentId)
        {
            return new EquipmentSetToEquipment
            {
                EquipmentSetID = equipmentSetId,
                EquipmentID = equipmentId
            };
        }        
    }
}

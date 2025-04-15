using System.Collections.Generic;

namespace Cmms.Domain.Entities
{
    public class EquipmentSet : EntityBase 
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<EquipmentSetToEquipment> EquipmentSetToEquipments { get; set; }
    }
}

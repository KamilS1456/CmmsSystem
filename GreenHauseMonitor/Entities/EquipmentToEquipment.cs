using System.Collections.Generic;

namespace Cmms.Entities
{
    public class EquipmentToEquipment
    {
        public int PrimalEquipmentId { get; set; }
        public int InnerEquipmentId { get; set; }
        
        public virtual Equipment PrimalEquipment { get; set; }
        public virtual Equipment InnerEquipment { get; set; }

    }
}

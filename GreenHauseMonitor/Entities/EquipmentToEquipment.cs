using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmms.Entities
{
    public class EquipmentToEquipment
    {
        public int Id { get; set; }

        [ForeignKey("CategoryId")]
        public int PrimalEquipmentId { get; set; }

        [ForeignKey("CategoryId")]
        public int InnerEquipmentId { get; set; }
        
        public virtual Equipment PrimalEquipment { get; set; }
        public virtual Equipment InnerEquipment { get; set; }

    }
}

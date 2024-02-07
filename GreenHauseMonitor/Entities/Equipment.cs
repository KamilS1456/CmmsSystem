using System;
using System.Collections.Generic;

namespace Cmms.Entities
{
    public class Equipment : EntityBase
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public Dictionary.Dictionary.EquipmentCondition Condition { get; set; }
        public DateTime LastServiceDateTime { get; set; }

        public virtual List<Equipment> PrimalEquipmentList { get; set; }
        public virtual List<Equipment> InnerEquipmentList { get; set; }
        //public virtual List<EquipmentToEquipment> EquipmentToEquipmentList { get; set; }


    }
}

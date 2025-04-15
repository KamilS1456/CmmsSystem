
using System;
using System.Collections.Generic;
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Domain.Entities
{
    public class Equipment : EntityBase
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public EquipmentCondition Condition { get; set; }
        public DateTime LastServiceDateTime { get; set; }

    }
}

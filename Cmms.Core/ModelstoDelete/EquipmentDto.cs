using System.Collections.Generic;
using System;
using Cmms.Domain.Dictionary;
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Core.Models
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public EquipmentCondition Condition { get; set; }
        public DateTime LastServiceDateTime { get; set; }
    }
}

using Cmms.Entities;
using System.Collections.Generic;
using System;

namespace Cmms.Models
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public Dictionary.Dictionary.EquipmentCondition Condition { get; set; }
        public DateTime LastServiceDateTime { get; set; }
    }
}

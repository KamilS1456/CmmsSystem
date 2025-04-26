using System;
using System.ComponentModel.DataAnnotations;
using static Cmms.Domain.Dictionary.EquipmentConditionEnum;

namespace Cmms.Requests.Equipment
{
    public class EquipmentUpdate
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public EquipmentCondition Condition { get; set; }
        public DateTime LastServiceDateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms.Models
{
    public class UpdateEquipmentDto
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public Dictionary.Dictionary.EquipmentCondition Condition { get; set; }
        public DateTime LastServiceDateTime { get; set; }

        public List<int> PrimalEquipmentIdList { get; set; }
        public List<int> InnerEquipmentIdList { get; set; }
    }
}

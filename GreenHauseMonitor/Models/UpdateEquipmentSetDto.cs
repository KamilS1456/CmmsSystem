using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms.Models
{
    public class UpdateEquipmentSetDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<int> SubEquipmentIdList { get; set; }
    }
}

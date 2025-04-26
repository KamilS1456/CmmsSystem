using Cmms.DtoModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cmms.Requests.EquipmentSet
{
    public class EquipmentSetCreate
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<EquipmentSetToEquipmentDto> EquipmentSetToEquipments { get; set; }


    }
}

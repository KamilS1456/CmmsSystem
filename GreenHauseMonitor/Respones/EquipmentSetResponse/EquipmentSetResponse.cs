using Cmms.DtoModels;
using System;
using System.Collections.Generic;

namespace Cmms.Respones.EquipmentSetResponse
{
    public class EquipmentSetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        IEnumerable<EquipmentSetToEquipmentDto> EquipmentSetToEquipments { get; set; }
    }
}

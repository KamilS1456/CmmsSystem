using Cmms.DtoModels;
using System;
using System.Collections.Generic;
using static Cmms.Domain.Dictionary.EquipmentConditionEnum;
using static Cmms.Domain.Dictionary.QuestStateEnum;

namespace Cmms.Respones.EquipmentSetResponse
{
    public class EquipmentSetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        IEnumerable<EquipmentSetToEquipmentDto> EquipmentSetToEquipments { get; set; }
    }
}

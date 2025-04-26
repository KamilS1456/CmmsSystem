using Cmms.DtoModels;
using System;
using System.Collections.Generic;
using static Cmms.Domain.Dictionary.EquipmentConditionEnum;
using static Cmms.Domain.Dictionary.QuestStateEnum;

namespace Cmms.Respones.EquipmentResponse
{
    public class EquipmentResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public EquipmentCondition Condition { get; set; }
        public DateTime LastServiceDateTime { get; set; }
    }
}

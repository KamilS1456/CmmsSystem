using Cmms.Domain.Entities;
using System.Collections.Generic;
using System;

namespace Cmms.Core.Models
{
    public class QuestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLineDataTime { get; set; }
        public int Priority { get; set; }
        public virtual List<Equipment> TargetedEquipments { get; set; }
    }
}

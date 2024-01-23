using Cmms.Entities;
using System.Collections.Generic;
using System;

namespace Cmms.Models
{
    public class QuestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLineDataTime { get; set; }
        public int Priority { get; set; }
        public virtual List<User> AssignedUsers { get; set; }
        public virtual List<Equipment> TargetedEquipments { get; set; }
    }
}

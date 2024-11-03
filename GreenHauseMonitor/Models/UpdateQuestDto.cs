using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms.Models
{
    public class UpdateQuestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLineDataTime { get; set; }
        public int Priority { get; set; }
        public List<QuestToUserDto> AssignedUsers { get; set; }
        public List<QuestToUserDto> TargetedEquipments { get; set; }
    }
}

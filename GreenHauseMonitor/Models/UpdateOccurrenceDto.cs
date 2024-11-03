using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Cmms.Dictionary.Dictionary;

namespace Cmms.Models
{
    public class UpdateOccurrenceDto
    {
        public string Description { get; set; }
        public int EquipmentId { get; set; }
        public int Priority { get; set; }
        public int OccurrenceTypeId { get; set; }
        public OccuranceState OccuranceState { get; set; } = OccuranceState.New;

    }
}

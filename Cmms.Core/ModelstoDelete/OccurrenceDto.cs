using Cmms.Domain.Entities;
using System.Collections.Generic;
using System;
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Core.Models
{
    public class OccurrenceDto
    {
        public int Id { get; set; }
        public DateTime OccurrenceDateTime { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public int EquipmentId { get; set; }
        public int Priority { get; set; }
        public int OccurrenceTypeId { get; set; }
        public OccuranceState OccuranceState { get; set; } = OccuranceState.New;

    }
}

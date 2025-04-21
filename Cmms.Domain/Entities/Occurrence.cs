using System;
using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Domain.Entities
{
    public class Occurrence : EntityBase
    {
        public DateTime OccurrenceDateTime { get; set; }
        public string Description { get; set; }
        public Guid EquipmentId { get; set; }
        public int Priority { get; set; }
        public Guid OccurrenceTypeId { get; set; }
        public OccuranceState OccuranceState { get; set; } = OccuranceState.New;

        public virtual Equipment Equipment { get; set; }
        public virtual OccurrenceType OccurrenceType { get; set; }
    }
}

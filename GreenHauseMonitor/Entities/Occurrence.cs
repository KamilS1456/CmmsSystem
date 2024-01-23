using System;

namespace Cmms.Entities
{
    public class Occurrence : EntityBase
    {
        public DateTime OccurrenceDateTime { get; set; }
        public string Description { get; set; }
        public int EquipmentId { get; set; }
        public int Priority { get; set; }
        public int OccurrenceTypeId { get; set; }


        public virtual Equipment Equipment { get; set; }
        public virtual OccurrenceType OccurrenceType { get; set; }
    }
}

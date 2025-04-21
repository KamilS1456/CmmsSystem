using System;
using System.Data;

namespace Cmms.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public Guid LastModifyByUserId { get; set; }
        public DateTime LastModifyDateTime { get; set; }
    }
}

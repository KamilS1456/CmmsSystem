using System;
using System.Data;

namespace Cmms.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; protected set; }
        public Guid? CreatedByUserId { get; protected set; }
        public DateTime CreationDateTime { get; protected set; }
        public Guid LastModifyByUserId { get; protected set; }
        public DateTime LastModifyDateTime { get; protected set; }
    }
}

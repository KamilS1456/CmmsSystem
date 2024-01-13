using System;
using System.Data;

namespace Cmms.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LastModifyByUserId { get; set; }
        public DateTime LastModifyDateTime { get; set; }
    }
}

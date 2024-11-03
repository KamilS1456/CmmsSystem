using Cmms.Entities;
using System.Collections.Generic;
using System;

namespace Cmms.Models
{
    public class EquipmentToEquipmentDto
    {
        public int Id { get; set; }
        public int PrimalEquipmentId { get; set; }
        public int InnerEquipmentId { get; set; }
    }
}
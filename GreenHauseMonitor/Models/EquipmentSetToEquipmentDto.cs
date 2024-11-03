using Cmms.Entities;
using System.Collections.Generic;
using System;

namespace Cmms.Models
{
    public class EquipmentSetToEquipmentDto
    {
        public int Id { get; set; }
        public int EquipmentSetID { get; set; }
        public int EquipmentID { get; set; }
    }
}
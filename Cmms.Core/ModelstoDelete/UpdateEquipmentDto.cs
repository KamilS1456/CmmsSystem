

using static Cmms.Domain.Dictionary.Dictionary;

namespace Cmms.Core.Models
{
    public class UpdateEquipmentDto
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public EquipmentCondition Condition { get; set; }
        public DateTime LastServiceDateTime { get; set; }

        public List<int> PrimalEquipmentIdList { get; set; }
        public List<int> InnerEquipmentIdList { get; set; }
    }
}

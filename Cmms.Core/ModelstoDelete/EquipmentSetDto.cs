
namespace Cmms.Core.Models
{
    public class EquipmentSetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<EquipmentSetToEquipmentDto> EquipmentSetToEquipments { get; set; }
    }
}

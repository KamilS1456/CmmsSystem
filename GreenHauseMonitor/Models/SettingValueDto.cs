using Cmms.Entities.Settings;
using Cmms.Entities;

namespace Cmms.Models
{
    public class SettingValueDto
    {
        public int Id { get; set; }

        public int SettingId { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
    }
}

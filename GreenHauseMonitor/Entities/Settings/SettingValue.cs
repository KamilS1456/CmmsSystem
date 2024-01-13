using System.Runtime.Serialization;
using System;

namespace Cmms.Entities.Settings
{
    public class SettingValue
    {
        public int Id { get; set; }

        public int SettingId { get; set; }
        public int? RoleId { get; set; }
        public int? UserId{ get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        public virtual Setting Setting { get; set; }


    }
}

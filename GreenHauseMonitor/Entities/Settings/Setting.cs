using System.Collections.Generic;

namespace Cmms.Entities.Settings
{
    public class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CodeName { get; set; }
        public SettingDictionary.SettingType ValueType { get; set; }

        public virtual List<SettingValueBool> SettingValueBoolList { get; set; }
        public virtual List<SettingValueInt> SettingValueIntList { get; set; }
    }
}

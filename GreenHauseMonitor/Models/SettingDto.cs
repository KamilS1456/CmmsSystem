using Cmms.Entities.Settings;
using System.Collections.Generic;

namespace Cmms.Models
{
    public class SettingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CodeName { get; set; }
        public SettingDictionary.SettingType ValueType { get; set; }      
        
        public List<SettingValueBoolDto> SettingValueBoolList { get; set; }
        public List<SettingValueIntDto> SettingValueIntList { get; set; }
    }
}

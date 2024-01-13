using Cmms.Models;
using System.Collections.Generic;

namespace Cmms.Services
{
    public interface ISettingService
    {
        IEnumerable<SettingDto> GetAll();
        SettingDto GetSettingById(int id);
        SettingValueBoolDto GetSettingBoolById(int id);
    }
}

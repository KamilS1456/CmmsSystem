using Cmms.EntitieDbCOntext;
using Microsoft.AspNetCore.Authorization;

namespace Cmms.Authorization
{
    public class SettingAllowedOperation : IAuthorizationRequirement
    {
        public string SettingName { get; }
        public SettingAllowedOperation(string settingName)
        {
            SettingName = settingName;
        }
    }
}

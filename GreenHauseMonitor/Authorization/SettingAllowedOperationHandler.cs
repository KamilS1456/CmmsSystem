using Cmms.EntitieDbCOntext;
using Cmms.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using System.Linq;
using Cmms.Entities.Settings;
using Cmms.Services;

namespace Cmms.Authorization
{
    public class SettingAllowedOperationHandler : AuthorizationHandler<SettingAllowedOperation, Restaurant>
    {
        private readonly CmmsDbContext _dbContext;
        private readonly ILogger<SettingAllowedOperationHandler> _logger;
        public SettingAllowedOperationHandler(CmmsDbContext dbContext, ILogger<SettingAllowedOperationHandler> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SettingAllowedOperation requirement, Restaurant resource)
        {
            var settingName = requirement.SettingName;
            if(!string.IsNullOrEmpty(settingName)) {
                int userId;
                if (int.TryParse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value, out userId))
                {
                    if (IsSettingRequarimentAccepted(settingName, userId)) {
                        _logger.LogInformation("Authorization succedded");
                        context.Succeed(requirement);
                    }
                }               
            } 
           
            return Task.CompletedTask;
        }
        private bool IsSettingRequarimentAccepted(string settingName,int userId)//do menagera ?
        {
            var setting = GetSetting(settingName);
            if (setting != null) {
                switch (setting.ValueType)  
                {
                    case SettingDictionary.SettingType.Boolean:
                        bool settingValue = false;
                        var settingValueUser = _dbContext.SettingValueBools.FirstOrDefault(f => f.UserId == userId);
                        if (settingValueUser != null&& false)
                        {
                            settingValue = settingValueUser.Value;
                        }
                        else { 
                            var user = _dbContext.Users.FirstOrDefault(f => f.Id == userId);
                            if (user != null){
                                var settinValueRole = _dbContext.SettingValueBools.FirstOrDefault(f => f.RoleId == user.RoleId);
                                if (settinValueRole != null)
                                {
                                    settingValue = false;//settinValueRole.Value;
                                }
                            }
                        }
                        return settingValue;
                        break;
                    case SettingDictionary.SettingType.Integer:
                        break;
                    case SettingDictionary.SettingType.String:
                        break;
                    case SettingDictionary.SettingType.Uniqueidentifier:
                        break;
                    default:
                        break;
                }
            }
            return false;
        }

        Setting GetSetting(string settingCodeName)//do menagera
        {
            return _dbContext.Settings.FirstOrDefault(f => f.CodeName == settingCodeName);
        }
    }
}

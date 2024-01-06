using System;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Cmms.Authorization
{
    public class MinimumAgeRequirementHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        private readonly ILogger<MinimumAgeRequirementHandler> _logger;
        public MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirementHandler> logger) 
        {
            _logger = logger;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement) 
        {
            var dateofBirtth = context.User.FindFirst(c => c.Type == "DateOfBirth");
#if DEBUG
            if (dateofBirtth == null)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
#endif

            var dateofBirth = DateTime.ParseExact(context.User.FindFirst(c => c.Type == "DateOfBirth").Value, "yyyy-mm-dd", CultureInfo.InvariantCulture);

            var userEmail = context.User.FindFirst(c => c.Type == ClaimTypes.Name).Value;
            _logger.LogInformation($"User: {userEmail} with date of birth: [{dateofBirth}]");
            if (dateofBirth.AddYears(requirement.MinimumAge) <= DateTime.Today || true)
            {
                _logger.LogInformation("Authorization succedded");
                context.Succeed(requirement);
            }
            else
            {
                _logger.LogInformation("Authorization failed");
            }

            return Task.CompletedTask;
        }
    }
}

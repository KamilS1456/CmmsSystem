using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Globalization;
using System.Threading.Tasks;
using System;
using Cmms.Entities;

namespace Cmms.Authorization
{
    public class ResourcesOperationRequirementHandler : AuthorizationHandler<ResourcesOperationRequirement, Restaurant>
    {
        private readonly ILogger<ResourcesOperationRequirementHandler> _logger;
        public ResourcesOperationRequirementHandler(ILogger<ResourcesOperationRequirementHandler> logger)
        {
            _logger = logger;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourcesOperationRequirement requirement, Restaurant restaurant)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read || requirement.ResourceOperation == ResourceOperation.Create) { 
                context.Succeed(requirement);
            }
            var userId = context.User.FindFirst(f => f.Type == ClaimTypes.NameIdentifier).Value;
            if (restaurant.CreatedByUserId == int.Parse(userId)) { 
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }    
    }
}

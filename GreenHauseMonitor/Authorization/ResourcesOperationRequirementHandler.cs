using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Globalization;
using System.Threading.Tasks;
using System;
using Cmms.Domain.Entities;

namespace Cmms.Authorization
{
    public class ResourcesOperationRequirementHandler : AuthorizationHandler<ResourcesOperationRequirement, Order>
    {
        private readonly ILogger<ResourcesOperationRequirementHandler> _logger;
        public ResourcesOperationRequirementHandler(ILogger<ResourcesOperationRequirementHandler> logger)
        {
            _logger = logger;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourcesOperationRequirement requirement, Order order)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read || requirement.ResourceOperation == ResourceOperation.Create) { 
                context.Succeed(requirement);
            }
            var userId = context.User.FindFirst(f => f.Type == ClaimTypes.NameIdentifier).Value;
            if (order.CreatedByUserId == int.Parse(userId)) { 
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }    
    }
}

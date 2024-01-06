using Microsoft.AspNetCore.Authorization;

namespace Cmms.Authorization
{
    public enum ResourceOperation
    { 
    Create,
    Read,
    Update,
    Delete
    }
    public class ResourcesOperationRequirement : IAuthorizationRequirement
    {
        public ResourcesOperationRequirement(ResourceOperation resourceOperation)
        { 
            ResourceOperation = resourceOperation;  
        }
        public ResourceOperation ResourceOperation { get;}
    }
}

using Microsoft.AspNetCore.Authorization;

namespace Cmms.Authorization
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get;}
        public MinimumAgeRequirement(int minimumAge) 
        {
            MinimumAge = minimumAge;
        }  
    }
}

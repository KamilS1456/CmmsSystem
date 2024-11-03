using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Cmms.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserContextService(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;            
        }

        public ClaimsPrincipal User { get { return _httpContextAccessor.HttpContext?.User; } }
        public int? GetUserId => User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public int? GetRoleId => User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.Role).Value);
    }
}

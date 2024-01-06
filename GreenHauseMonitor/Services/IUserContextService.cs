using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Cmms.Services
{
    public interface IUserContextService
    {
        public ClaimsPrincipal User { get; }
        public int? GetUserId { get; }
    }
}

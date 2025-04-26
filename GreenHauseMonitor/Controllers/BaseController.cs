using AutoMapper;
using Cmms.Core.Models;
using Cmms.Respones.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;
using System.Linq;
using Cmms.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Cmms.Controllers
{
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            var apiError = new ErrorResponse();

            if (errors.Any(e => e.Code == ErrorCode.NotFound))
            {
                var error = errors.FirstOrDefault(e => e.Code == ErrorCode.NotFound);

                apiError.StatusCode = 404;
                apiError.StatusPhrase = "Not Found";
                apiError.Timestamp = DateTime.Now;
                apiError.Errors.Add(error.Message);

                return NotFound(apiError);
            }

            apiError.StatusCode = 400;
            apiError.StatusPhrase = "Bad request";
            apiError.Timestamp = DateTime.Now;
            errors.ForEach(e => apiError.Errors.Add(e.Message));
            return StatusCode(400, apiError);
        }

        public static Guid GetUserProfileIdClaimValue(HttpContext context)
        {
            return GetGuidClaimValue("UserProfileId", context);
        }

        public static Guid GetIdentityIdClaimValue(HttpContext context)
        {
            return GetGuidClaimValue("IdentityId", context);
        }

        private static Guid GetGuidClaimValue(string key, HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            return Guid.Parse(identity?.FindFirst(key)?.Value);
        }
    }
}

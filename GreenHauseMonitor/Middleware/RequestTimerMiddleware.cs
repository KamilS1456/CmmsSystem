using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms.Middleware
{
    public class RequestTimerMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimerMiddleware> _logger;
        private readonly Stopwatch _stopwatch;
        public RequestTimerMiddleware(ILogger<RequestTimerMiddleware> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }
        async public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Restart();
            await next.Invoke(context);
            _stopwatch.Stop();

            var requestTime = _stopwatch.ElapsedMilliseconds / 1000;
            if (requestTime > 4)
            {
                _logger.LogInformation($"Reqest [{context.Request.Method}] at [{context.Request.Path}] took {requestTime}");
            }
        }
    }
}

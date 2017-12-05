using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Framework.Middlewares
{
    public class VisitLogMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger logger;

        private VisitLog visitLog;

        public VisitLogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            logger = loggerFactory.CreateLogger<VisitLogMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            visitLog = new VisitLog();
            HttpRequest request = context.Request;
            visitLog.Url = request.Path.ToString();
            visitLog.Headers = request.Headers.ToDictionary(k => k.Key, v => string.Join(";", v.Value.ToList()));
            visitLog.Method = request.Method;
            visitLog.ExcuteStartTime = DateTime.Now;

            using (var reader = new StreamReader(request.Body))
            {
                visitLog.RequestBody = reader.ReadToEnd();
            }

            context.Response.OnCompleted(ResponseCompletedCallback, context);
            await _next(context);
        }

        private Task ResponseCompletedCallback(object obj)
        {
            visitLog.ExcuteEndTime = DateTime.Now;
            logger.LogInformation($"VisitLog: {visitLog.ToString()}");
            return Task.FromResult(0);
        }
    }
}

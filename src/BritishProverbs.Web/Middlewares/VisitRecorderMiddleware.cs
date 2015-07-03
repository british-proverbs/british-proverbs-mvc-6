using System;
using System.Threading.Tasks;
using BritishProverbs.Domain;
using BritishProverbs.Web.Utils;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Logging;

namespace BritishProverbs.Web.Middlewares
{
    public class VisitRecorderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public VisitRecorderMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<VisitRecorderMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext, IBritishProverbsContext proverbsContext)
        {
            try
            {
                await proverbsContext.RecordVisitAsync(httpContext.GetClientIPAddress());
            }
            catch(Exception ex)
            {
                _logger.LogError("Failed while recording the visit.", ex);
            }
            finally
            {
                await _next(httpContext);
            }
        }
    }
}

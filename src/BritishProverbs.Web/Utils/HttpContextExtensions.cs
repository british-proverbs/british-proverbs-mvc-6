using System;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features;

namespace BritishProverbs.Web.Utils
{
    public static class HttpContextExtensions
    {
        public static string GetClientIPAddress(this HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            IHttpConnectionFeature connection = context.GetFeature<IHttpConnectionFeature>();

            return connection != null
                ? connection.RemoteIpAddress.ToString()
                : null;
        }
    }
}

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Mhlabs.WebApi.JsendActionFilter
{
    internal class HandleExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<HandleExceptionFilterAttribute> _logger;

        public HandleExceptionFilterAttribute(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger<HandleExceptionFilterAttribute>();
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            _logger.LogError(context.Exception, "JSend OnException - Error Message {Message}. Route: {RouteDisplayName}",
                context?.Exception?.Message, context?.ActionDescriptor?.DisplayName);

            if (!context.HasJSendHeader()) return;
            
            var result = new ObjectResult(new { status = "error", message = context.Exception.Message })
            {
                StatusCode = (int?)HttpStatusCode.InternalServerError
            };
            context.Result = result;
        }
    }
}
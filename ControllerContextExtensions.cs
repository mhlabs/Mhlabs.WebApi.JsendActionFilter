using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Mhlabs.WebApi.JsendActionFilter
{
    internal static class ControllerContextExtensions
    {
        public static bool HasJSendHeader(this ControllerContext controllerContext)
        {
            var filter =
                (ResponseFilterAttribute) controllerContext.ActionDescriptor.FilterDescriptors
                    .FirstOrDefault(fd => fd.Filter.GetType() == typeof(ResponseFilterAttribute)).Filter;

            return filter != null && controllerContext.HttpContext.Request.Headers?[filter.ResponseFormatHeader]
                       .FirstOrDefault() == filter.JSendHeaderValue;
        }
    }
}
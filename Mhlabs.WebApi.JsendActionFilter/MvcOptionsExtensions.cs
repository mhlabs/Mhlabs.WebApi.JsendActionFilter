using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mhlabs.WebApi.JsendActionFilter
{
    public static class MvcOptionsExtensions
    {
        public static void AddJSendResponseFormat(this MvcOptions options)
        {
            options.Filters.Add(new ResponseFilterAttribute());
            options.Filters.Add<HandleExceptionFilterAttribute>();
        }
    }
}
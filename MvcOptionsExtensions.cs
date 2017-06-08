using Microsoft.AspNetCore.Mvc;

namespace Mhlabs.WebApi.JsendActionFilter
{
    public static class MvcOptionsExtensions
    {
        public static void AddJSendResponseFormat(this MvcOptions options)
        {
            options.Filters.Add(new ResponseFilterAttribute());
            options.Filters.Add(new HandleExcpetionFilterAttribute());
        }
    }
}
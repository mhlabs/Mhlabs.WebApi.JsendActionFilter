using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mhlabs.WebApi.JsendActionFilter
{
    public static class FilterContextExtensions
    {
        public static bool HasJSendHeader(this FilterContext context)
        {
            var filter = context.Filters.First(f => f.GetType() == typeof(ResponseFilterAttribute)) as ResponseFilterAttribute;

            return filter != null && context.HttpContext.Request.Headers?[filter.ResponseFormatHeader]
                       .FirstOrDefault() == filter.JSendHeaderValue;
        }
    }
}
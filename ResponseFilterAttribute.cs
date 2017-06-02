using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mhlabs.WebApi.JsendActionFilter
{
    public class ResponseFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            if (context.Exception == null && context.HasJsendHeader())
            {

                if (context.RouteData.DataTokens.ContainsKey("jsend-status"))
                {
                    var responseData = context.RouteData.DataTokens["jsend-status"];

                    ((ObjectResult)context.Result).Value =
                        new { status = "fail", data = responseData };
                }
                else
                {
                    ((ObjectResult)context.Result).Value =
                        new { status = "success", data = ((ObjectResult)context.Result).Value };
                }
            }
        }

    }

    public static class FilterContextExtension
    {
        public static bool HasJsendHeader(this FilterContext context)
        {
            return context.HttpContext.Request.Headers?["X-Response-Format"].FirstOrDefault() == "jsend";
        }
    }
}
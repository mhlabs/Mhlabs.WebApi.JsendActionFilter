using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mhlabs.WebApi.JsendActionFilter
{
    public class ResponseFilterAttribute : ActionFilterAttribute
    {
        public string ResponseFormatHeader { get; internal set; } = "X-Response-Format";
        public string JSendHeaderValue { get; internal set; } = "jsend";

        public ResponseFilterAttribute()
        {
        }

        public ResponseFilterAttribute(string responseFormatHeader = null, string jSendHeaderValue = null)
        {
            ResponseFormatHeader = responseFormatHeader ?? ResponseFormatHeader;
            JSendHeaderValue = jSendHeaderValue ?? JSendHeaderValue;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            if (!context.HasJSendHeader()) return;

            if (context.Exception != null && context.Exception.GetType() == typeof(JSendFailException))
            {
                var failExeption = context.Exception as JSendFailException;

                if (context.Result != null) return;

                context.Result = new OkObjectResult(new {status = "fail", data = failExeption?.FailData});
                context.ExceptionHandled = true;
            }
            else if (context.Exception == null)
            {
                ((ObjectResult)context.Result).Value =
                    new { status = "success", data = ((ObjectResult)context.Result).Value };
            }
        }

    }
}
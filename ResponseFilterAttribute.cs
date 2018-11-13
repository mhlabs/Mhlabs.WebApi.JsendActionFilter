using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Mhlabs.WebApi.JsendActionFilter
{
    internal class ResponseFilterAttribute : ActionFilterAttribute
    {
        public ResponseFilterAttribute()
        {
        }

        public ResponseFilterAttribute(string responseFormatHeader = null, string jSendHeaderValue = null)
        {
            ResponseFormatHeader = responseFormatHeader ?? ResponseFormatHeader;
            JSendHeaderValue = jSendHeaderValue ?? JSendHeaderValue;
        }

        public string ResponseFormatHeader { get; internal set; } = "X-Response-Format";
        public string JSendHeaderValue { get; internal set; } = "jsend";

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            if (!context.HasJSendHeader()) return;

            var result = context.Result as OkObjectResult;
            if (result != null && result.Value as JSendResponse != null)
            {
                // error response already set
                return;
            }

            if (context.Exception != null && context.Exception.GetType() == typeof(JSendFailException))
            {
                var failExeption = context.Exception as JSendFailException;

                if (context.Result != null) return;


                context.Result = new OkObjectResult(new { status = "fail", data = failExeption?.FailData });

                var logError = $"[ERROR] Result: {JsonConvert.SerializeObject(failExeption?.FailData)}";
                Console.WriteLine(logError);

                context.ExceptionHandled = true;
            }
            else if (context.Exception == null)
            {
                var objectResult = context.Result as ObjectResult;
                if(objectResult == null) return;
                objectResult.Value =
                    new JSendResponse { Status = "success", Data = objectResult.Value};
            }
        }
    }
}
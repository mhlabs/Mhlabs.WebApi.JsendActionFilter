using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mhlabs.WebApi.JsendActionFilter
{
    internal class HandleExcpetionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            if (!context.HasJSendHeader()) return;
            var result =
                new ObjectResult(new {status = "error", message = context.Exception.Message})
                {
                    StatusCode = (int?) HttpStatusCode.InternalServerError
                };
            context.Result = result;
        }
    }

}
using System;
using Microsoft.AspNetCore.Mvc;

namespace Mhlabs.WebApi.JsendActionFilter
{
    public static class Jsend
    {
        public static void Fail(this Controller controller, object data)
        {
            if (controller.ControllerContext.HasJSendHeader())
                throw new JSendFailException(data);

            var exception = new Exception("Request Failed");
            exception.Data.Add("FailData", data);
        }

        public static void Fail(this Controller controller, string code = null, string message = null)
        {
            Fail(controller, new FailReason(code, message));
        }
    }
}
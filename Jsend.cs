using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            throw exception;
        }

        public static void Fail(this Controller controller, string code = null, string message = null)
        {
            Fail(controller, new FailReason(code, message));
        }

        public static OkObjectResult Error(this Controller controller, FailReason data)
        {
            var response = new JSendResponse { Status = "fail", Data = data };
            Console.WriteLine($"[ERROR] JSendResponse: {JsonConvert.SerializeObject(response)} {Environment.NewLine}");

            return new OkObjectResult(response);
        }

        public static OkObjectResult Error(this Controller controller, string code = null, string message = null)
        {
            return Error(controller, new FailReason(code, message));
        }

    }
}
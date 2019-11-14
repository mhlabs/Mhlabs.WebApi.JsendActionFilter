using System;
using System.Collections.Generic;
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

        public static void Fail(this Controller controller, string code = null, string message = null, IDictionary<string, object> metadata = null)
        {
            Fail(controller, new FailReason(code, message, metadata));
        }

        public static ObjectResult Error(this Controller controller, FailReason data)
        {
            if (!controller.ControllerContext.HasJSendHeader())
            {
                return new ObjectResult(data)
                {
                    StatusCode = 500
                };
            }

            var response = new JSendResponse { Status = "fail", Data = data };
            Console.WriteLine($"[ERROR] JSendResponse: {JsonConvert.SerializeObject(response)} {Environment.NewLine}");

            return new OkObjectResult(response);
        }

        public static ObjectResult Error(this Controller controller, string code = null, string message = null)
        {
            return Error(controller, new FailReason(code, message));
        }

    }
}
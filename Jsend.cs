using Microsoft.AspNetCore.Mvc;

namespace Mhlabs.WebApi.JsendActionFilter
{
    public static class Jsend
    {
        public static void Fail(this Controller controller, object data)
        {
            controller.RouteData.DataTokens.Add("jsend-status", data);
        }
    }
}

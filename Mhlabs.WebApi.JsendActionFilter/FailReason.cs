namespace Mhlabs.WebApi.JsendActionFilter
{
    public class FailReason
    {
        public FailReason(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; set; }
        public string Message { get; set; }
    }
}
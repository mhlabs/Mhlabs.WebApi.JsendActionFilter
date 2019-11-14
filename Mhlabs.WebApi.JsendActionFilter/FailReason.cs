using System.Collections.Generic;

namespace Mhlabs.WebApi.JsendActionFilter
{
    public class FailReason
    {
        public FailReason(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public FailReason(string code, string message, IDictionary<string, object> metadata)
        {
            Code = code;
            Message = message;
            Metadata = metadata ?? new Dictionary<string, object>();
        }

        public string Code { get; set; }
        public string Message { get; set; }
        public IDictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    }
}
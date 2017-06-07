using System;

namespace Mhlabs.WebApi.JsendActionFilter
{
    public class JSendFailException : Exception
    {
        private const string FailDataKey = "FailData";

        public object FailData
        {
            get => Data[FailDataKey];
            set => Data[FailDataKey] = value;
        }

        public JSendFailException(object data)
        {
            FailData = data;
        }
    }
}
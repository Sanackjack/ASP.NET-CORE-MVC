using System.Globalization;
using RestFulASPNET.models;

namespace RestFulASPNET.Exceptions
{
    public class ServiceInvalidParamException : Exception
    {
        public String code { get; set; }
        public ServiceInvalidParamException() : base() { }

        public ServiceInvalidParamException(string message) : base(message) { }
        public ServiceInvalidParamException(string code ,string message) : base(message) {
            this.code = code;
        }

        public ServiceInvalidParamException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
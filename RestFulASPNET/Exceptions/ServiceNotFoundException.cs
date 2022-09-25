using System;
using System.Globalization;
namespace RestFulASPNET.Exceptions
{
    public class ServiceNotFoundException : Exception
    {
        public String code { get; set; }
        public ServiceNotFoundException() : base() { }

        public ServiceNotFoundException(string message) : base(message) { }
        public ServiceNotFoundException(string code, string message) : base(message)
        {
            this.code = code;
        }
        public ServiceNotFoundException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
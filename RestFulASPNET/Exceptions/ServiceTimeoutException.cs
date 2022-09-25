using System;
using System.Globalization;
namespace RestFulASPNET.Exceptions
{
    public class ServiceTimeoutException : Exception
    {
        public String code { get; set; }
        public ServiceTimeoutException() : base() { }

        public ServiceTimeoutException(string message) : base(message) { }
        public ServiceTimeoutException(string code, string message) : base(message)
        {
            this.code = code;
        }
        public ServiceTimeoutException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
using System;
using System.Globalization;
namespace RestFulASPNET.Exceptions
{
    public class ServiceSystemException : Exception
    {
        public String code { get; set; }
        public ServiceSystemException() : base() { }

        public ServiceSystemException(string message) : base(message) { }
        public ServiceSystemException(string code, string message) : base(message)
        {
            this.code = code;
        }

        public ServiceSystemException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}

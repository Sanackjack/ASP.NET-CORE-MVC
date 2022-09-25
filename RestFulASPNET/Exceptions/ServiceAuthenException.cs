using System;
using System.Globalization;
namespace RestFulASPNET.Exceptions
{
	public class ServiceAuthenException : Exception
	{
        public String code { get; set; }
        public ServiceAuthenException() : base() { }

        public ServiceAuthenException(string message) : base(message) { }
        public ServiceAuthenException(string code, string message) : base(message)
        {
            this.code = code;
        }
        public ServiceAuthenException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}


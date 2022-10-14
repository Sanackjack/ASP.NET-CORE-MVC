using System;
using System.Globalization;
using RestFulASPNET.Constants;

namespace RestFulASPNET.Exceptions
{
	public class AuthenticateException : CommonException
	{
        public String? userName { get; set; }

        public AuthenticateException(ResponseCodes response) : base(response.Code, response.Message, response.HttpStatus) { }

        public AuthenticateException(string code, string message, int httpStatus) : base(code, message, httpStatus) { }

        public AuthenticateException(string code, string message, int httpStatus , Exception exception) : base(code, message, httpStatus ,exception) { }

        public AuthenticateException(string code, string message, int httpStatus , string userName) : base(code, message, httpStatus)
        {
            this.userName = userName;
        }
    }
}
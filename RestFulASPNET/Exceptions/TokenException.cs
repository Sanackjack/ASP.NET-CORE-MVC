using System;
using RestFulASPNET.Constants;

namespace RestFulASPNET.Exceptions
{
    public class TokenException : CommonException
    {

        public TokenException(ResponseCodes response) : base(response.Code, response.Message, response.HttpStatus) { }

        public TokenException(string code, string message, int httpStatus) : base(code, message, httpStatus) { }

        public TokenException(string code, string message, int httpStatus, Exception exception) : base(code, message, httpStatus, exception) { }
    }
}


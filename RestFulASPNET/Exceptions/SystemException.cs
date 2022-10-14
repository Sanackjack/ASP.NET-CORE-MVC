using System;
using RestFulASPNET.Constants;

namespace RestFulASPNET.Exceptions
{
    public class SystemException : CommonException
    {

        public SystemException(ResponseCodes response) : base(response.Code, response.Message, response.HttpStatus) { }

        public SystemException(string code, string message, int httpStatus) : base(code, message, httpStatus) { }

        public SystemException(string code, string message, int httpStatus, Exception exception) : base(code, message, httpStatus, exception) { }
    }
}


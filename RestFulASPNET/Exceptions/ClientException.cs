using System;
using RestFulASPNET.Exceptions;
using RestFulASPNET.Constants;

namespace RestFulASPNET.Exceptions
{
    public class ClientException : CommonException
    {

        public ClientException(ResponseCodes response) : base(response.Code, response.Message, response.HttpStatus) { }

        public ClientException(string code, string message, int httpStatus) : base(code, message, httpStatus) { }

        public ClientException(string code, string message, int httpStatus, Exception exception) : base(code, message, httpStatus, exception) { }
    }

}



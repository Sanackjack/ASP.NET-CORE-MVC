using System;
using RestFulASPNET.Constants;

namespace RestFulASPNET.Exceptions
{
    public class ValidationException : CommonException
    {
        public String? massageDetailInValid { get; set; }

        public ValidationException(ResponseCodes response) : base(response.Code, response.Message, response.HttpStatus) { }

        public ValidationException(string code, string message, int httpStatus) : base(code, message, httpStatus) { }

        public ValidationException(string code, string message, int httpStatus, Exception exception) : base(code, message, httpStatus, exception) { }

        public ValidationException(string code, string message, int httpStatus, Exception exception, string massageDetailInValid) : base(code, message, httpStatus, exception)
        {
            this.massageDetailInValid = massageDetailInValid;
        }
    }
}


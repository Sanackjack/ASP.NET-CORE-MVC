using System;
using RestFulASPNET.Constants;

namespace RestFulASPNET.Exceptions
{

        public class ExternalException : CommonException
        {
            public String? partnerName { get; set; }

            public ExternalException(ResponseCodes response) : base(response.Code, response.Message, response.HttpStatus) { }

            public ExternalException(string code, string message, int httpStatus) : base(code, message, httpStatus) { }

            public ExternalException(string code, string message, int httpStatus, Exception exception) : base(code, message, httpStatus, exception) { }

            public ExternalException(string code, string message, int httpStatus, Exception exception,string partnerName) : base(code, message, httpStatus, exception)
            {
                this.partnerName = partnerName;
            }
        }
}



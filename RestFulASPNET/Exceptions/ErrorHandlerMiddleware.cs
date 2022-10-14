using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RestFulASPNET.models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using RestFulASPNET.Constants;
namespace RestFulASPNET.Exceptions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                String code = ResponseCodes.SYSTEM_ERROR.Code;
                String msg = ResponseCodes.SYSTEM_ERROR.Message;
                var response = context.Response;
                response.ContentType = "application/json";
                switch (error)
                {
                    case AuthenticateException e:
                        code = e.code;
                        msg = String.IsNullOrEmpty(e.userName)
                            ? e.message : String.Format("[{0}]{1}", e.userName, e.message);
                        response.StatusCode = e.httpStatus;
                        break;
                    case ClientException e:
                        code = e.code;
                        msg = e.message;
                        response.StatusCode = e.httpStatus;
                        break;
                    case ValidationException e:
                        code = e.code;
                        msg = String.IsNullOrEmpty(e.massageDetailInValid)
                            ? e.message: String.Format("{0} The problem is {1}",e.message,e.massageDetailInValid) ;
                        response.StatusCode = e.httpStatus;
                        break;
                    case TokenException e:
                        code = e.code;
                        msg = e.message;
                        response.StatusCode = e.httpStatus;
                        break;
                    case ExternalException e:
                        code = e.code;
                        msg = String.IsNullOrEmpty(e.partnerName)
                            ? e.message : String.Format("[{0}]{1}", e.partnerName, e.message);
                        response.StatusCode = e.httpStatus;
                        break;
                    case SystemException e:
                        code = e.code;
                        msg  = e.message;
                        response.StatusCode = e.httpStatus;

                        if (e.exception != null)
                            _logger.LogError(e.exception, e.exception.Message);
                        break;
                    default:
                        _logger.LogError(error, error.Message);
                        response.StatusCode = ResponseCodes.SYSTEM_ERROR.HttpStatus;
                        break;
                }
                var genericResponse = new GenericResponse(new StatusResponse(code, msg));
                var result = JsonSerializer.Serialize(genericResponse);
                await response.WriteAsync(result);
            }
        }
    }

}
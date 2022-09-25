using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RestFulASPNET.models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
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
                String code = "A-999";
                String msg = "";
                var response = context.Response;
                response.ContentType = "application/json";
                switch (error)
                {
                    case ServiceInvalidParamException e:
                        code = e.code;
                        msg = e.Message;
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ServiceTimeoutException e:
                        code = e.code;
                        msg = e.Message;
                        response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                        break;
                    case ServiceNotFoundException e:
                        code = e.code;
                        msg = e.Message;
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case ServiceSystemException e:
                        code = e.code;
                        msg = e.Message;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    case KeyNotFoundException e: 
                        // not found error from framework lib
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        _logger.LogError(error, error.Message);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var genericResponse = new GenericResponse(new StatusResponse(code, msg));
                var result = JsonSerializer.Serialize(genericResponse);
                await response.WriteAsync(result);
            }
        }
    }

}
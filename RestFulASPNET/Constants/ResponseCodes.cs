using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.Xml;
using System.Threading;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RestFulASPNET.Constants
{
	public class ResponseCodes
	{
        public string Code { get; private set; }
        public string Message { get; private set; }
        public int HttpStatus { get; private set; }

        ResponseCodes(string code, string message, int httpStatus) => (Code, Message, HttpStatus) = (code, message, httpStatus);


        public static IEnumerable<ResponseCodes> Values
        {
            get
            {
                yield return SUCCESS;
                yield return DATA_CREATE;
                yield return DATA_REMOVE;
                yield return DATA_UPDATE;
                yield return AUTHENTICATION_FAIL;
                yield return INCORRECT_USERNAME_PASSWORD;
                yield return USER_LOCK;
                yield return USER_NOT_ACTIVE;
                yield return SIGNATURE_NOT_MATCH;
                yield return TOKEN_GENERATE_FAIL;
                yield return TOKEN_EXPIRED;
                yield return TOKEN_INVALID;
                yield return TOKEN_IS_NULL;
                yield return TOKEN_ERROR;
                yield return TOKEN_NOT_AUTHORIZE;
                yield return REFRESH_TOKEN_GENERATE_FAIL;
                yield return REFRESH_TOKEN_EXPIRED;
                yield return REFRESH_TOKEN_INVALID;
                yield return REFRESH_TOKEN_IS_NULL;
                yield return REFRESH_TOKEN_ERROR;
                yield return DATA_NOT_FOUND;
                yield return DATA_DUPLICATE;
                yield return DATA_SUSPENDED;
                yield return DATA_NOT_ACTIVE;
                yield return DATABASE_LOCK;
                yield return DATABASE_ERROR;
                yield return BAD_REQUEST_CONNECTION;
                yield return CONNECTION_ERROR;
                yield return CONNECTION_TIMED_OUT;
                yield return CONNECTION_WAF_LIMIT;
                yield return CONNECTION_RATE_LIMIT;
                yield return CONNECTION_WAS_BANNED;
                yield return CONNECTION_TOO_MANY_REQUESTS;
                yield return VALIDATION_REQUEST_PARAMETER_FAIL;
                yield return VALIDATION_REQUEST_HEADER_FAIL;
                yield return VALIDATION_REQUEST_UNSUPPORTED_MEDIA_TYPE;
                yield return VALIDATION_REQUEST_METHOD_FAIL;
                yield return VALIDATION_LOGIC_FAIL;
                yield return VALIDATION_BUSINESS_FAIL;
                yield return THIRD_PARTY_MAINTAIN;
                yield return THIRD_PARTY_SERVICE_UNAVAILABLE;
                yield return THIRD_PARTY_BAD_REQUEST;
                yield return THIRD_PARTY_BUSINESS_ERROR;
                yield return THIRD_PARTY_TRANSACTION_ERROR;
                yield return THIRD_PARTY_AUTHENTICATE_ERROR;
                yield return THIRD_PARTY_DATA_NOT_FOUND;
                yield return THIRD_PARTY_SYSTEM_ERROR;
                yield return THIRD_PARTY_CONNECT_TIMEOUT;
                yield return THIRD_PARTY_CONNECT_ERROR;
                yield return THIRD_PARTY_UNKNOWN_ERROR_CODE;
                yield return SERVICE_MAINTAIN;
                yield return SERVICE_UNAVAILABLE;
                yield return SYSTEM_ERROR;
                yield return INTERNAL_SERVER_ERROR;
                yield return UNKNOWN_ERROR;
            }
        }

        //0 Case : Success
        public static readonly ResponseCodes SUCCESS     = new ResponseCodes("0", "Success", (int)HttpStatusCode.OK);
        public static readonly ResponseCodes DATA_CREATE = new ResponseCodes("0", "Success", (int)HttpStatusCode.Created);
        public static readonly ResponseCodes DATA_REMOVE = new ResponseCodes("0", "Success", (int)HttpStatusCode.OK);
        public static readonly ResponseCodes DATA_UPDATE = new ResponseCodes("0", "Success", (int)HttpStatusCode.OK);

        //1xxx Case : Authenticate logic error
        public static readonly ResponseCodes AUTHENTICATION_FAIL         = new ResponseCodes("1001", "Authentication fail.", (int)HttpStatusCode.Unauthorized);
        public static readonly ResponseCodes INCORRECT_USERNAME_PASSWORD = new ResponseCodes("1002", "Username or Password is incorrect.", (int)HttpStatusCode.Unauthorized);
        public static readonly ResponseCodes USER_LOCK                   = new ResponseCodes("1003", "Username is lock.", (int)HttpStatusCode.Unauthorized);
        public static readonly ResponseCodes USER_NOT_ACTIVE             = new ResponseCodes("1004", "Username is not active.", (int)HttpStatusCode.Unauthorized);
        public static readonly ResponseCodes SIGNATURE_NOT_MATCH         = new ResponseCodes("1005", "Signature does not match or invalid.", (int)HttpStatusCode.Unauthorized);

        //2xxx Case : Token logic error
        public static readonly ResponseCodes TOKEN_GENERATE_FAIL         = new ResponseCodes("2001", "Token generate fail.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes TOKEN_EXPIRED               = new ResponseCodes("2002", "Token is Expired.", (int)HttpStatusCode.Forbidden);
        public static readonly ResponseCodes TOKEN_INVALID               = new ResponseCodes("2003", "Token is invalid.", (int)HttpStatusCode.Unauthorized);
        public static readonly ResponseCodes TOKEN_IS_NULL               = new ResponseCodes("2004", "Token is null.", (int)HttpStatusCode.Forbidden);
        public static readonly ResponseCodes TOKEN_ERROR                 = new ResponseCodes("2005", "Token error or exception.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes TOKEN_NOT_AUTHORIZE         = new ResponseCodes("2006", "Not authorize for is Token.", (int)HttpStatusCode.Forbidden);
        public static readonly ResponseCodes REFRESH_TOKEN_GENERATE_FAIL = new ResponseCodes("2007", "Refresh token generate fail.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes REFRESH_TOKEN_EXPIRED       = new ResponseCodes("2008", "Refresh token is Expired.", (int)HttpStatusCode.Forbidden);
        public static readonly ResponseCodes REFRESH_TOKEN_INVALID       = new ResponseCodes("2009", "Refresh token is invalid.", (int)HttpStatusCode.Unauthorized);
        public static readonly ResponseCodes REFRESH_TOKEN_IS_NULL       = new ResponseCodes("2010", "Refresh token is null.", (int)HttpStatusCode.Forbidden);
        public static readonly ResponseCodes REFRESH_TOKEN_ERROR         = new ResponseCodes("2011", "Refresh token error or exception.", (int)HttpStatusCode.InternalServerError);

        //3xxx Case : Data or Database error
        public static readonly ResponseCodes DATA_NOT_FOUND  = new ResponseCodes("3001", "Data not found.", (int)HttpStatusCode.NoContent);
        public static readonly ResponseCodes DATA_DUPLICATE  = new ResponseCodes("3002", "Data duplicate.", (int)HttpStatusCode.Conflict);
        public static readonly ResponseCodes DATA_SUSPENDED  = new ResponseCodes("3003", "Data was block or suspend.", (int)HttpStatusCode.Forbidden);
        public static readonly ResponseCodes DATA_NOT_ACTIVE = new ResponseCodes("3004", "Data is not active.", (int)HttpStatusCode.NoContent);
        public static readonly ResponseCodes DATABASE_LOCK   = new ResponseCodes("3998", "Database is lock.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes DATABASE_ERROR  = new ResponseCodes("3999", "Data was error or exception.", (int)HttpStatusCode.InternalServerError);

        //4xxx Case : Client connection error
        public static readonly ResponseCodes BAD_REQUEST_CONNECTION       = new ResponseCodes("4001", "Client request is invalid.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes CONNECTION_ERROR             = new ResponseCodes("4002", "Client connection is error.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes CONNECTION_TIMED_OUT         = new ResponseCodes("4003", "Client connection timeout.", (int)HttpStatusCode.RequestTimeout);
        public static readonly ResponseCodes CONNECTION_WAF_LIMIT         = new ResponseCodes("4004", "Client connection WAF limit.", (int)HttpStatusCode.TooManyRequests);
        public static readonly ResponseCodes CONNECTION_RATE_LIMIT        = new ResponseCodes("4005", "Client connection rate limit.", (int)HttpStatusCode.TooManyRequests);
        public static readonly ResponseCodes CONNECTION_WAS_BANNED        = new ResponseCodes("4006", "Client connection was banned.", (int)HttpStatusCode.Forbidden);
        public static readonly ResponseCodes CONNECTION_TOO_MANY_REQUESTS = new ResponseCodes("4007", "Client connection too many request.", (int)HttpStatusCode.TooManyRequests);

        //5xxx Case : Validate client request error
        public static readonly ResponseCodes VALIDATION_REQUEST_PARAMETER_FAIL         = new ResponseCodes("5001", "Validate request parameter fail.", (int)HttpStatusCode.BadRequest);
        public static readonly ResponseCodes VALIDATION_REQUEST_HEADER_FAIL            = new ResponseCodes("5002", "Validate request header fail.", (int)HttpStatusCode.BadRequest);
        public static readonly ResponseCodes VALIDATION_REQUEST_UNSUPPORTED_MEDIA_TYPE = new ResponseCodes("5003", "Validate request type fail.", (int)HttpStatusCode.UnsupportedMediaType);
        public static readonly ResponseCodes VALIDATION_REQUEST_METHOD_FAIL            = new ResponseCodes("5004", "Method Failure.", (int)HttpStatusCode.MethodNotAllowed);
        public static readonly ResponseCodes VALIDATION_LOGIC_FAIL                     = new ResponseCodes("5005", "Validate logic fail. ", (int)HttpStatusCode.BadRequest);
        public static readonly ResponseCodes VALIDATION_BUSINESS_FAIL                  = new ResponseCodes("5006", "Validate business fail. ", (int)HttpStatusCode.BadRequest);

        //6xxx Case : Third-party or external connection error
        public static readonly ResponseCodes THIRD_PARTY_MAINTAIN            = new ResponseCodes("6000", "Third party service on maintain.", (int)HttpStatusCode.ServiceUnavailable);
        public static readonly ResponseCodes THIRD_PARTY_SERVICE_UNAVAILABLE = new ResponseCodes("6001", "Third party service not available.", (int)HttpStatusCode.ServiceUnavailable);
        public static readonly ResponseCodes THIRD_PARTY_BAD_REQUEST         = new ResponseCodes("6002", "Third party bad request.", (int)HttpStatusCode.BadRequest);
        public static readonly ResponseCodes THIRD_PARTY_BUSINESS_ERROR      = new ResponseCodes("6003", "Third party business error.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes THIRD_PARTY_TRANSACTION_ERROR   = new ResponseCodes("6004", "Third party transaction error.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes THIRD_PARTY_AUTHENTICATE_ERROR  = new ResponseCodes("6005", "Third party authentication error.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes THIRD_PARTY_DATA_NOT_FOUND      = new ResponseCodes("6006", "Third party data not found.", (int)HttpStatusCode.NoContent);
        public static readonly ResponseCodes THIRD_PARTY_SYSTEM_ERROR        = new ResponseCodes("6996", "Third party system error.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes THIRD_PARTY_CONNECT_TIMEOUT     = new ResponseCodes("6997", "Third party connection timeout error.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes THIRD_PARTY_CONNECT_ERROR       = new ResponseCodes("6998", "Third party connection connection error.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes THIRD_PARTY_UNKNOWN_ERROR_CODE  = new ResponseCodes("6999", "Third party connection unknown error.", (int)HttpStatusCode.InternalServerError);

        //9xxx Case : System error
        public static readonly ResponseCodes SERVICE_MAINTAIN      = new ResponseCodes("9000", "Service on maintain.", (int)HttpStatusCode.ServiceUnavailable);
        public static readonly ResponseCodes SERVICE_UNAVAILABLE   = new ResponseCodes("9001", "Service not available.", (int)HttpStatusCode.ServiceUnavailable);
        public static readonly ResponseCodes SYSTEM_ERROR          = new ResponseCodes("9997", "System error.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes INTERNAL_SERVER_ERROR = new ResponseCodes("9998", "Internal Server error.", (int)HttpStatusCode.InternalServerError);
        public static readonly ResponseCodes UNKNOWN_ERROR         = new ResponseCodes("9999", "Unknown error.", (int)HttpStatusCode.InternalServerError);

    }
}
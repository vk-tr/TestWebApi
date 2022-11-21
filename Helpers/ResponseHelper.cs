using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using TestWebApi.Exceptions;

namespace TestWebApi.Helpers
{
    public static class ResponseHelper
    {
        public static HttpResponseMessage ThrowCatch(Action action)
        {
            try
            {
                action();
                return ThrowOk();
            }
            catch (ApiException ex)
            {
                return ThrowError(ex);
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }
        private static HttpResponseMessage ThrowOk()
        {
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            return responseMessage;
        }
        private static HttpResponseMessage ThrowError(Exception exception)
        {
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = GetErrorCode(exception),
                ReasonPhrase = exception.Message
            };

            return responseMessage;
        }

        private static HttpStatusCode GetErrorCode(Exception e)
        {
            switch (e)
            {
                case ValidationException _:
                    return HttpStatusCode.BadRequest;
                case AuthenticationException _:
                    return HttpStatusCode.Forbidden;
                case NotImplementedException _:
                    return HttpStatusCode.NotImplemented;
                case ApiException _:
                    return HttpStatusCode.BadRequest;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
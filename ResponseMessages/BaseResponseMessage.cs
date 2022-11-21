using System.Net;
using System.Net.Http;

namespace TestWebApi.ResponseMessages
{
    public class BaseResponseMessage : HttpResponseMessage
    {
        private new HttpStatusCode StatusCode { get; set; }

        private new string? ReasonPhrase { get; set; }

        protected BaseResponseMessage(
            HttpStatusCode statusCode,
            string? reasonPhrase)
        {
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
        }
    }
}
using System.Net;

namespace TestWebApi.ResponseMessages
{
    public class BadRequestResponseMessage : BaseResponseMessage
    {
        public BadRequestResponseMessage(string? reasonPhrase)
            : base(HttpStatusCode.BadRequest, reasonPhrase)
        {
            StatusCode = HttpStatusCode.BadRequest;
            ReasonPhrase = reasonPhrase;
        }
    }
}
using System;

namespace TestWebApi.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message)
            : base(message)
        {
        }
    }
}
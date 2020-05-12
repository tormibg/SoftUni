using System;

namespace Work.HTTP
{
    class HttpServerException : Exception
    {
        public HttpServerException(string message) : base(message)
        {
            
        }
    }
}

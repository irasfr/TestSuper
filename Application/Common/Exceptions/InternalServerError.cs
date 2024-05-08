using System;

namespace Application.Common.Exceptions
{
    public class InternalServerError : Exception
    {
        public InternalServerError(string message)
            : base($"Internal Server Error: {message}.") { }
    }
}
using System;

namespace APIClientes.Services.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : 
            base(message)
        {
        }
    }
}

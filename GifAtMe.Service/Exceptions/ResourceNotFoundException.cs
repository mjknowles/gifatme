using System;

namespace GifAtMe.Service.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message)
            : base(message)
        { }

        public ResourceNotFoundException()
            : base("The requested resource was not found.")
        { }
    }
}
using System;

namespace BookStore.Domain.Exceptions
{
    public class AppLogicException : Exception
    {
        public AppLogicException(string message = null) : base(message)
        {
        }
    }
}

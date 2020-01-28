using System;

namespace BookStore.Domain.Exceptions
{
    public class AuthorException : Exception
    {
        public AuthorException(string message = null) : base(message)
        {
        }
    }
}

using System;

namespace BookStore.Domain.Exceptions
{
    public class BookException : Exception
    {
        public BookException(string message = null) : base(message)
        {
        }
    }
}

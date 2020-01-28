using System;

namespace BookStore.Domain.Exceptions
{
    public class GenreException : Exception
    {
        public GenreException(string message = null) : base(message)
        {
        }
    }
}

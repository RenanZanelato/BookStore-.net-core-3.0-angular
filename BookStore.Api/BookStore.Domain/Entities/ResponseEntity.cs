using System;

namespace BookStore.Domain.Entities
{
    public class ResponseEntity
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public Exception Detailed { get; set; }
    }
}

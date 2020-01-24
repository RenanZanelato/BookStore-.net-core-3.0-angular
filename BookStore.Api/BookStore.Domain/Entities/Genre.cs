using System;
using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public IList<BookGenre> BookGenre { get; set; }
    }
}

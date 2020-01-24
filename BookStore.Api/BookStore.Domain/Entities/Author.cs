using System;
using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public IList<BookAuthor> BookAuthor { get; set; }
    }
}

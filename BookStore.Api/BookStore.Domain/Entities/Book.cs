using System;
using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public IList<BookAuthor> BookAuthor { get; set; }
        public IList<BookGenre> BookGenre { get; set; }
    }
}

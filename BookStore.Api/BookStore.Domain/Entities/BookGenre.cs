using System;

namespace BookStore.Domain.Entities
{
    public class BookGenre
    { 
  
        public Guid GenreId { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}

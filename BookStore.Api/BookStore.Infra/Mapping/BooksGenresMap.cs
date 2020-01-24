using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Mapping
{
    class BooksGenresMap
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.ToTable("books_genres");
            builder.HasKey(p => new { p.BookId, p.GenreId });
            builder.HasOne<Book>(p => p.Book)
                .WithMany(s => s.BookGenre);
            builder.HasOne<Genre>(p => p.Genre)
                .WithMany(s => s.BookGenre);

        }
    }
}

using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Mapping
{
    class BooksAuthorsMap
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable("books_authors");
            builder.HasKey(p => new { p.BookId,p.AuthorId });
            builder.HasOne<Book>(p => p.Book)
                .WithMany(s => s.BookAuthor);
            builder.HasOne<Author>(p => p.Author)
                .WithMany(s => s.BookAuthor);
        }
    }
}

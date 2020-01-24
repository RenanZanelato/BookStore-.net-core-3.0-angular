using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Mapping
{
    class BooksMap
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id)
                .IsUnique();
            builder.Property(u => u.Name).IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Description).IsRequired()
                .HasMaxLength(250);
            builder.Property(u => u.PublishDate).IsRequired();

           


        }
    }
}

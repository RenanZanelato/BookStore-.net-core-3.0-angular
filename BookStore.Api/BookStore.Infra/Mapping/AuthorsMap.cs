using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Mapping
{
    class AuthorsMap
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("author");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id)
                .IsUnique();
            builder.Property(u => u.Name).IsRequired()
                .HasMaxLength(100);

            builder.HasMany<Book>();

        }
    }
}

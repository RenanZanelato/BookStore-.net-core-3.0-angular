using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infra.Mapping
{
    class GenresMap
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genres");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id)
                .IsUnique();
            builder.Property(u => u.Name).IsRequired()
                .HasMaxLength(100);

            builder.HasMany<Book>();

        }
    }
}

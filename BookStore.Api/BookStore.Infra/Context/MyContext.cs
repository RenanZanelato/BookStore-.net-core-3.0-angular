using BookStore.Domain.Entities;
using BookStore.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>(new BooksMap().Configure);
            modelBuilder.Entity<Author>(new AuthorsMap().Configure);
            modelBuilder.Entity<Genre>(new GenresMap().Configure);

            modelBuilder.Entity<BookAuthor>(new BooksAuthorsMap().Configure);
            modelBuilder.Entity<BookGenre>(new BooksGenresMap().Configure);
        }
    }
}

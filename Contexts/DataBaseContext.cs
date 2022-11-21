using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.Models;

namespace TestWebApi.Contexts
{
    public sealed class DataBaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DataBaseContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Books.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateBooksTable(modelBuilder.Entity<Book>());
            CreateReservationsTable(modelBuilder.Entity<Reservation>());
        }

        private void CreateBooksTable(EntityTypeBuilder<Book> books)
        {
            books.ToTable(nameof(DataBaseContext.Books))
                .HasKey(book => book.Id);

            books.Property(book => book.Id).IsRequired();
            books.Property(book => book.Title).IsRequired();

            books.Property(book => book.IsReserved);
        }

        private void CreateReservationsTable(EntityTypeBuilder<Reservation> reservations)
        {
            reservations.ToTable(nameof(DataBaseContext.Reservations))
                .HasKey(res => res.Id);

            reservations.Property(res => res.Id).IsRequired();
            reservations.Property(res => res.BookId).IsRequired();
            reservations.Property(res => res.Comment);
        }
    }
}
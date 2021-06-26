using BookStore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Review>()
                .ToTable("Reviews");

            builder.Entity<Book>()
                .Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(8, 2)");

            builder.Entity<PriceOffer>()
                .Property(p => p.NewPrice)
                .IsRequired()
                .HasColumnType("decimal(8, 2)");

            builder.Entity<PriceOffer>()
                .Property<long>("BookId");

            builder.Entity<PriceOffer>()
                .HasOne(p => p.Book)
                .WithOne(p => p.Promotion)
                .HasForeignKey<PriceOffer>("BookId");

            builder.Entity<Book>()
                .HasMany(p => p.Tags)
                .WithMany(p => p.Books)
                .UsingEntity(j => j.ToTable("BooksTags"));

            builder.Entity<BookAuthor>()
                .Property<long>("BookId");

            builder.Entity<BookAuthor>()
                .Property<long>("AuthorId");

            builder.Entity<BookAuthor>()
                .ToTable("BooksAuthors");

            builder.Entity<Book>()
                .HasMany(p => p.Authors)
                .WithMany(p => p.Books)
                .UsingEntity<BookAuthor>(
                    q => q
                        .HasOne(a => a.Author)
                        .WithMany(b => b.BooksAuthors)
                        .HasForeignKey("AuthorId"),
                    q => q
                        .HasOne(ba => ba.Book)
                        .WithMany(b => b.BooksAuthors)
                        .HasForeignKey("BookId"),
                    q => q.HasKey("BookId", "AuthorId"));
        }
    }
}

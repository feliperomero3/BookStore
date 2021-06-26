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

            builder.Entity<Book>(b =>
            {
                b.Property(t => t.Title)
                 .IsRequired()
                 .HasMaxLength(255);

                b.Property(t => t.Description)
                 .IsRequired()
                 .HasMaxLength(255);

                b.Property(p => p.Price)
                 .IsRequired()
                 .HasColumnType("decimal(8, 2)");

                b.Property(t => t.ImageUrl)
                 .HasMaxLength(255);
            });

            builder.Entity<PriceOffer>(p =>
            {
                p.Property(p => p.NewPrice)
                 .IsRequired()
                 .HasColumnType("decimal(8, 2)");

                p.Property(p => p.PromotionalText)
                 .HasMaxLength(255);

                p.Property<long>("BookId");

                p.HasOne(p => p.Book)
                 .WithOne(p => p.Promotion)
                 .HasForeignKey<PriceOffer>("BookId");
            });

            builder.Entity<Book>()
                .HasMany(p => p.Tags)
                .WithMany(p => p.Books)
                .UsingEntity(j => j.ToTable("BooksTags"));

            builder.Entity<Author>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Entity<Review>(r =>
            {
                r.Property(p => p.ReviewerName)
                 .IsRequired()
                 .HasMaxLength(255);

                r.Property(p => p.Comment)
                 .IsRequired()
                 .HasMaxLength(255);

                r.Property<long>("BookId");
            });

            builder.Entity<Tag>()
                .Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(255);

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

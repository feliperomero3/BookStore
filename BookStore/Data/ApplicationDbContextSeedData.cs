using System;
using System.Linq;
using BookStore.Entities;

namespace BookStore.Data
{
    internal static class ApplicationDbContextSeedData
    {
        internal static void SeedDatabase(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return; // Db has been seeded
            }

            var review1 = new Review("John Smith", 5, "This is serious book about domain modeling in software design.");
            var review2 = new Review("Steve Grubbs", 5, "An Underrated Subject and Book.");
            var review3 = new Review("Frederick Thompson", 5, "Another solid book by Robert Martin.");

            var book1 = new Book(
                "Domain-Driven Design",
                "Illustrates the application of domain-driven design to real-world software development.",
                DateTime.Parse("2003-08-20"),
                56m,
                "images/domain-driven-design.png",
                new[] { new Author("Eric Evans") },
                new[] { new Tag("Editor's Choice") },
                new[] { review1 });

            var book2 = new Book(
                "Patterns of Enterprise Application Architecture",
                "Presents patterns (proven solutions to recurring problems) in enterprise architecture.",
                DateTime.Parse("2002-11-05"),
                34m,
                "images/patterns-of-enterprise-application-architecture.png",
                new[] { new Author("Martin Fowler") },
                new[] { new Tag("Architecture") },
                new[] { review2 });

            var book3 = new Book(
                "Clean Code: A Handbook of Agile Software Craftsmanship",
                "Best agile practices of cleaning code \"on the fly\" that will instill within you the values of a software craftsman.",
                DateTime.Parse("2008-08-01"),
                45m,
                "images/clean-code.png",
                new[] { new Author("Robert C. Martin") },
                new[] { new Tag("Refactoring") },
                new[] { review3 });

            context.AddRange(book1, book2, book3);
            context.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;

namespace BookStore.Entities
{
    public class Book
    {
        public long BookId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime PublishedOn { get; private set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
        public ICollection<Author> Authors { get; private set; }
        public ICollection<Tag> Tags { get; private set; }
        public ICollection<Review> Reviews { get; private set; }
        public PriceOffer Promotion { get; private set; }
        public List<BookAuthor> BooksAuthors { get; private set; }

        private Book()
        {
            Authors = new HashSet<Author>();
            Tags = new HashSet<Tag>();
            Reviews = new HashSet<Review>();
            BooksAuthors = new List<BookAuthor>();
        }

        public Book(string title, string description, DateTime publishedOn, decimal price, string imageUrl,
             ICollection<Author> authors, ICollection<Tag> tags = null, ICollection<Review> reviews = null) : base()
        {
            Title = title;
            Description = description;
            PublishedOn = publishedOn;
            Price = price;
            ImageUrl = imageUrl;
            Authors = authors;
            Tags = tags;
            Reviews = reviews;
        }
    }
}

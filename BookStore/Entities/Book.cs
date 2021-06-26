using System;
using System.Collections.Generic;

namespace BookStore.Entities
{
    public class Book
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public PriceOffer Promotion { get; set; }
        public List<BookAuthor> BooksAuthors { get; set; }
    }
}

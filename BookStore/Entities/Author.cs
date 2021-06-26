using System.Collections.Generic;

namespace BookStore.Entities
{
    public class Author
    {
        public long AuthorId { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
        public List<BookAuthor> BooksAuthors { get; set; }
    }
}

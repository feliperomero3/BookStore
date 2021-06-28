using System.Collections.Generic;

namespace BookStore.Entities
{
    public class Author
    {
        public long AuthorId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Book> Books { get; private set; }
        public List<BookAuthor> BooksAuthors { get; private set; }

        private Author()
        {
            Books = new HashSet<Book>();
            BooksAuthors = new List<BookAuthor>();
        }

        public Author(string name)
        {
            Name = name;
        }
    }
}

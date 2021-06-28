using System.Collections.Generic;

namespace BookStore.Entities
{
    public class Tag
    {
        public Tag(string value)
        {
            Value = value;
        }

        private Tag()
        {
            Books = new HashSet<Book>();
        }

        public long TagId { get; private set; }
        public string Value { get; private set; }
        public ICollection<Book> Books { get; private set; }
    }
}

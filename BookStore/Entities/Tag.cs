using System.Collections.Generic;

namespace BookStore.Entities
{
    public class Tag
    {
        public long TagId { get; set; }
        public string Value { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}

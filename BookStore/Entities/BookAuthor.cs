namespace BookStore.Entities
{
    public class BookAuthor
    {
        public Book Book { get; set; }
        public Author Author { get; set; }
        public int Order { get; set; }
    }
}

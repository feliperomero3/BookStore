namespace BookStore.Entities
{
    public class Review
    {
        public long ReviewId { get; set; }
        public string ReviewerName { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
        public Book Book { get; set; }
    }
}

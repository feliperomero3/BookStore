namespace BookStore.Entities
{
    public class Review
    {
        public Review(string reviewerName, int starts, string comment)
        {
            ReviewerName = reviewerName;
            Stars = starts;
            Comment = comment;
        }

        private Review()
        {

        }

        public long ReviewId { get; private set; }
        public string ReviewerName { get; private set; }
        public int Stars { get; private set; }
        public string Comment { get; private set; }
        public Book Book { get; private set; }
    }
}

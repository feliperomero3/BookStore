namespace BookStore.Entities
{
    public class PriceOffer
    {
        public long PriceOfferId { get; set; }
        public decimal NewPrice { get; set; }
        public string PromotionalText { get; set; }
        public Book Book { get; set; }
    }
}

namespace WebApplication3.EntityModels
{
    public class Review
    {
        public long ID { get; set; }
        public string Author { get; set; }
        public DateOnly Date { get; set; }
        public double Rating { get; set; }
        public int MaxRating { get; set; }
        public string Text { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace WebApplication3.EntityModels
{
    public class Attraction
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public int MaxRating { get; set; }
        public int? RatingCount { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Site { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Duration { get; set; }
        public string? Prices { get; set; }
        public string? Image { get; set; }
        public string Url { get; set; }
        public virtual WorkingHours WorkingHours { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
        public virtual List<Cuisine> Cuisines { get; set; }
        public virtual List<FoodRestriction> FoodRestrictions { get; set; }
    }
}

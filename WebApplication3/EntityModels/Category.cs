namespace WebApplication3.EntityModels
{
    public class Category 
    {
        public long ID { get; set; }
        public string Name { get; set; } 
        public List<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
        //public virtual List<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
    public class SubCategory
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }
}

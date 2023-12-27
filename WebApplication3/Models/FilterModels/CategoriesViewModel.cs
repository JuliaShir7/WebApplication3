namespace WebApplication3.Models.FilterModels
{
    public class CategoriesViewModel
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public SubCategoriesViewModel SubCategoriesViewModel { get; set; }
    }
}

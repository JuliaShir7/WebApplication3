using WebApplication3.Interfaces;

namespace WebApplication3.Models.FilterModels
{
    public class SubCategoriesViewModel
    {
        public List<CheckViewModel> LikedSubCategories { get; set; }
        public List<CheckViewModel> DislikedSubCategories { get; set; }
        //public List<string> Cities { get; set; }

        public SubCategoriesViewModel()
        {
            LikedSubCategories = new List<CheckViewModel>();
            DislikedSubCategories = new List<CheckViewModel>();
        }
    }
}

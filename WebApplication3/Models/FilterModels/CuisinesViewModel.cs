namespace WebApplication3.Models.FilterModels
{
    public class CuisinesViewModel
    {
        public List<CheckViewModel> LikedCuisines { get; set; }
        public List<CheckViewModel> DislikedCuisines{ get; set; }
        //public List<string> Cities { get; set; }

        public CuisinesViewModel()
        {
            LikedCuisines = new List<CheckViewModel>();
            DislikedCuisines = new List<CheckViewModel>();
        }
    }
}

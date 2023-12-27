using WebApplication3.EntityModels;

namespace WebApplication3.Models.FilterModels
{
    public class TopPlacesViewModel
    {
        public List<CheckViewModel> TopPlacesLiked { get; set; }
        public List<CheckViewModel> TopPlacesDisliked { get; set; }

        public TopPlacesViewModel()
        {
            TopPlacesLiked = new List<CheckViewModel>();
            TopPlacesDisliked = new List<CheckViewModel>();
        }
    }
}

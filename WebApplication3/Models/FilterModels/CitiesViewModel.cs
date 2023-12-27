using WebApplication3.Interfaces;

namespace WebApplication3.Models.FilterModels
{
    public class CitiesViewModel
    {
        public List<CheckViewModel> GoodCitiesList { get; set; }
        public List<CheckViewModel> BadCitiesList { get; set; }
        //public List<string> Cities { get; set; }

        public CitiesViewModel()
        {
            GoodCitiesList = new List<CheckViewModel>();
            BadCitiesList = new List<CheckViewModel>();
            //Cities = new List<string>();
        }

    }
}

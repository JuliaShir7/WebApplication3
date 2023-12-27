using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Text;
using WebApplication3.Models;
using WebApplication3.Models.FilterModels;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        public HomeController(/*ILogger<HomeController> logger*/)
        {
           // _logger = logger;
        }

        public ActionResult Index()
        {
            //CityList cities = new CityList
            //{
            //    CitiesList = new List<City> { new City { ID = 1, Name = "London", IsSelected=false },
            //    new City { ID = 2, Name = "Paris", IsSelected=false }, new City { ID = 3, Name = "Berlin" }, new City { ID = 4, Name = "Moscow" } }
            //};


            //List<CityViewModel> cit = new List<CityViewModel>() { new CityViewModel { ID = 1, Name = "London", IsSelected=false },
            //    new CityViewModel { ID = 2, Name = "Paris", IsSelected=false }, new CityViewModel { ID = 3, Name = "Berlin" }, new CityViewModel { ID = 4, Name = "Moscow" } };
          
            //List<CityViewModel> c = new List<CityViewModel>();
            //c.AddRange(cit);

            //CitiesViewModel cities = new CitiesViewModel();
            //cities.GoodCitiesList = cit;
            //cities.BadCitiesList = c;
            return View(/*cities*/);
        }

        public IActionResult Privacy()
        {
            return View();
        }
 
        //[HttpPost]
        //public ActionResult Index(List<City> items, List<City> citiesAnti)
        //{
        //    ViewBag.Message = "Selected Items:\\n";
        //    List<City> ct = new List<City>();
        //    foreach (City item in items)
        //    {
        //        if (item.IsSelected)
        //        {
        //            ViewBag.Message += string.Format("{0}\\n", item.Name);
        //            ct.Add(item);
        //        }
        //    }
        //    foreach (City item in citiesAnti)
        //    {
        //        if (item.IsSelected)
        //        {
        //            ViewBag.Message += string.Format("{0}\\n", item.Name);
        //            ct.Add(item);
        //        }
        //    }
        //    return View(ct);
        //}






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Text;
using WebApplication3.Models.FilterModels;
using WebApplication3.Interfaces;

namespace WebApplication3.Controllers
{
    public class FinalFilterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IServiceProvider _service;
        //private HttpClient _httpClient;
        public FinalFilterController(IHttpClientFactory httpClientFactory, IServiceProvider service)
        {
            _httpClientFactory = httpClientFactory;
            _service = service;
        }
        //public FinalFilterController(FilterModelDTO filterModelDTO) 
        //{ 
        //    _cacheModel= filterModelDTO;
        //}

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult> FinalFilter(FilterModelDTO filterModelDTO, string first, string second, string third,
        //   string fourth, string fifth, string sixth, string seventh)
        //{
        //    int[] marks = new int[] { Convert.ToInt32(first), Convert.ToInt32(second), Convert.ToInt32(third), Convert.ToInt32(fourth),
        //    Convert.ToInt32(fifth), Convert.ToInt32(sixth), Convert.ToInt32(seventh) };

        //    sendModel.Marks = marks;

        //    using (var httpClient = _httpClientFactory.CreateClient("localhost"))
        //    {
        //        var url = httpClient.BaseAddress + "/Filter/final_filter";
        //        var json = System.Text.Json.JsonSerializer.Serialize(filterModelDTO);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");
        //        var response = httpClient.PostAsync(url, content).Result;

        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            var responseContent = response.Content.ReadAsStringAsync().Result;
        //            //var res = JsonConvert.DeserializeObject<List<List<Attraction>>>(responseContent);

        //            //var topTen = _service.GetService<FilterService>().GetTopTenPlaces(res[0]);
        //            //FilterModelDTO sendModel = new FilterModelDTO(group, city, oldage, youngage, transport, trip_start, trip_end, attractions[0], attractions[1], topTen);
        //            return View();
        //            //return View("~/Views/Filter/FinalFilter/_Index.cshtml", sendModel);
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //}
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using WebApplication3.EntityModels;
using WebApplication3.Interfaces;
using WebApplication3.Models.FilterModels;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class FilterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IServiceProvider _service;
        private IMemoryCache _memoryCache;
       
        //private HttpClient _httpClient;
        public FilterController(IHttpClientFactory httpClientFactory, IServiceProvider service, IMemoryCache memoryCache)
        {
            _httpClientFactory = httpClientFactory;
            _service = service;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (var httpClient = _httpClientFactory.CreateClient("localhost"))
            {
                List<Category> categories = GetCategories();
                List<FoodRestriction> foodRestrictions = GetFoodRestrictions();
                List<Cuisine> cuisines = GetCuisines();
                FilterViewModel filterModel = new FilterViewModel(categories, foodRestrictions, cuisines);

                return View(filterModel);                
            }
        }

        [HttpPost]
        public async Task<ActionResult> GeneralFilter(FilterViewModel filterModel, string group, string city, string oldage, string youngage,
            string transport, DateTime trip_start, DateTime trip_end)
        {
            FilterModelDTO model = new FilterModelDTO(city, filterModel.FoodRestrictions, filterModel.Cuisines, filterModel.CategoriesViewModel);

            using (var httpClient = _httpClientFactory.CreateClient("localhost"))
            {
                var url = httpClient.BaseAddress + "/Analyse/filter";
                var json = System.Text.Json.JsonSerializer.Serialize(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(url, content).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var attractions = JsonConvert.DeserializeObject<List<List<Attraction>>>(responseContent);
                    var topTen = _service.GetService<FilterService>().GetTopTenPlaces(attractions[0]);
                    FilterModelDTO sendModel = new FilterModelDTO(group, city, oldage, youngage, transport, trip_start, trip_end, attractions[0], attractions[1], topTen);
                    
                    FilterModelDTO cacheModel = new FilterModelDTO(group, city, oldage, youngage, transport, trip_start, trip_end, attractions[0], attractions[1], topTen, model.SubCategoriesLiked, model.CuisinesLiked);
                    _memoryCache.Set("FilterModelDTO", cacheModel);

                    return View("~/Views/Filter/FinalFilter/Index.cshtml", sendModel);
                }
                else
                {
                    return BadRequest();
                }
            }     
        }

        [HttpPost]
        public async Task<ActionResult> FinalFilter(FilterModelDTO filterModelDTO, string first, string second, string third,
            string fourth, string fifth, string sixth, string seventh)
        {
            int[] marks = new int[] { Convert.ToInt32(first), Convert.ToInt32(second), Convert.ToInt32(third), Convert.ToInt32(fourth),
            Convert.ToInt32(fifth), Convert.ToInt32(sixth), Convert.ToInt32(seventh) };

           _memoryCache.TryGetValue("FilterModelDTO", out FilterModelDTO sendModel);
            sendModel.Marks = marks;
            sendModel.TopPlacesLiked = filterModelDTO.TopPlacesLiked;
            sendModel.TopPlacesDisliked = filterModelDTO.TopPlacesDisliked;
            

            using (var httpClient = _httpClientFactory.CreateClient("localhost"))
            {
                var url = httpClient.BaseAddress + "/Analyse/data_analyse";
                var json = System.Text.Json.JsonSerializer.Serialize(sendModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(url, content).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<List<List<Attraction>>>(responseContent);

                    return View();
                    //return View("~/Views/Filter/FinalFilter/_Index.cshtml", sendModel);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        private List<Category> GetCategories()
        {
            using (var httpClient = _httpClientFactory.CreateClient("localhost"))
            {
                List<Category> categories = new List<Category>();
                HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Information/GetCategories").Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result.ToString();
                    categories = JsonConvert.DeserializeObject<List<Category>>(data);
                }

                return categories;
            }
        }
        private List<FoodRestriction> GetFoodRestrictions()
        {
            using (var httpClient = _httpClientFactory.CreateClient("localhost"))
            {
                List<FoodRestriction> foodRestrictions = new List<FoodRestriction>();
                HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Information/GetFoodRestrictions").Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result.ToString();
                    foodRestrictions = JsonConvert.DeserializeObject<List<FoodRestriction>>(data);
                }

                return foodRestrictions;
            }
        }

        private List<Cuisine> GetCuisines()
        {
            using (var httpClient = _httpClientFactory.CreateClient("localhost"))
            {
                List<Cuisine> cuisines = new List<Cuisine>();
                HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Information/GetCuisines").Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result.ToString();
                    cuisines = JsonConvert.DeserializeObject<List<Cuisine>>(data);
                }

                return cuisines;
            }

        }
    }
}

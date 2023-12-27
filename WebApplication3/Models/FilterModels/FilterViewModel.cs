using Newtonsoft.Json;
using WebApplication3.EntityModels;
using WebApplication3.Helpers;
using WebApplication3.Interfaces;

namespace WebApplication3.Models.FilterModels
{
    public enum Transport
    {
        OnFeet = 0,
        Auto = 1,
        Bicycle = 2
    }
    public class SelectionModel
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }

    public class FilterViewModel
    {
        public List<string> Cities { get; set; }
        public List<SelectionModel> YoungAge { get; set; }
        public List<SelectionModel> OldAge { get; set; }
        //public CitiesViewModel CitiesViewModel { get; set; }
        public List<SelectionModel> Transport { get; set; }
        public List<CheckViewModel> FoodRestrictions { get; set; }
        public CuisinesViewModel Cuisines { get; set; }
        public List<CategoriesViewModel> CategoriesViewModel { get; set; }
        //public List<CheckViewModel> TopPlaces { get; set; }


        public FilterViewModel(List<Category> categories, List<FoodRestriction> foodRestrictions, List<Cuisine> cuisines)
        {
            //CitiesViewModel = PutTestData();
            Cities = JsonConverters.GetCities();
            OldAge = GetAgeModel(GetOlderAgeGroups());
            YoungAge = GetAgeModel(JsonConverters.GetAgeGroups());
            Transport = ReturnTransport();
            CreateCategoryModel(categories);
            CreateFoodRestrictions(foodRestrictions);
            Cuisines = CreateCuisines(cuisines);
        }

        public FilterViewModel()
        {
            //CitiesViewModel = PutTestData();
            Cities = JsonConverters.GetCities();
            OldAge = GetAgeModel(GetOlderAgeGroups());
            YoungAge = GetAgeModel(JsonConverters.GetAgeGroups());
            Transport = ReturnTransport();
        }



        List<SelectionModel> GetAgeModel(Dictionary<string, int> model)
        {
            List<SelectionModel> result = new List<SelectionModel>();
            foreach (var y in model.Keys)
            {
                result.Add(new SelectionModel { Name = y, IsSelected = false });
            }

            return result;
        }

        //private CitiesViewModel PutTestData()
        //{
        //    List<CheckViewModel> cities = new List<CheckViewModel>() { new CheckViewModel { ID = 1, Name = "London", IsSelected=false },
        //        new CheckViewModel { ID = 2, Name = "Paris", IsSelected=false }, new CheckViewModel { ID = 3, Name = "Berlin" }, new CheckViewModel { ID = 4, Name = "Moscow" } };

        //    List<CheckViewModel> checkModel = new List<CheckViewModel>();
        //    checkModel.AddRange(cities);

        //    CitiesViewModel citiesModel = new CitiesViewModel();
        //    citiesModel.GoodCitiesList = cities;
        //    citiesModel.BadCitiesList = checkModel;

        //    return citiesModel;
        //}

        private Dictionary<string, int> GetOlderAgeGroups()
        {
            var ageGroup = JsonConverters.GetAgeGroups();
            Dictionary<string, int> older = new Dictionary<string, int>();
            foreach (var i in ageGroup.Keys)
            {
                if (ageGroup[i] >= 18)
                    older.Add(i, ageGroup[i]);
            }

            return older;
        }

        private List<SelectionModel> ReturnTransport()
        {
            Transport = new List<SelectionModel> {
                new SelectionModel { Name = "Пешком", IsSelected = false },
                new SelectionModel{ Name="На велосипеде", IsSelected = false },
                new SelectionModel{ Name= "На автомобиле", IsSelected = false }
            };

            return Transport;
        }

        private void CreateCategoryModel(List<Category> categories)
        {
            CategoriesViewModel = new List<CategoriesViewModel>();

            foreach (var category in categories)
            {
                CategoriesViewModel.Add(new CategoriesViewModel
                {
                    ID = category.ID,
                    Name = category.Name,
                    SubCategoriesViewModel = ReturnSubCategories(category.SubCategories)
                });
            }
        }

        private SubCategoriesViewModel ReturnSubCategories(List<SubCategory> subCategories)
        {
            var SubCategoriesViewModel = new SubCategoriesViewModel();

            foreach (var subcategory in subCategories)
            {
                SubCategoriesViewModel.LikedSubCategories.Add(new CheckViewModel
                {
                    ID = subcategory.ID,
                    Name = subcategory.Name,
                    IsSelected = false
                });

                SubCategoriesViewModel.DislikedSubCategories.Add(new CheckViewModel
                {
                    ID = subcategory.ID,
                    Name = subcategory.Name,
                    IsSelected = false
                });
            }

            return SubCategoriesViewModel;
        }

        private void CreateFoodRestrictions(List<FoodRestriction> foodRestrictions)
        {
            FoodRestrictions = new List<CheckViewModel>();

            foreach (var restriction in foodRestrictions)
            {
                FoodRestrictions.Add(new CheckViewModel
                {
                    ID = restriction.ID,
                    Name = restriction.Name,
                    IsSelected = false
                });
            }
        }

        private CuisinesViewModel CreateCuisines(List<Cuisine> cuisines)
        {
            var cuisinesViewModel = new CuisinesViewModel();

            foreach (var cuisine in cuisines)
            {
                cuisinesViewModel.LikedCuisines.Add(new CheckViewModel
                {
                    ID = cuisine.ID,
                    Name = cuisine.Name,
                    IsSelected = false
                });

                cuisinesViewModel.DislikedCuisines.Add(new CheckViewModel
                {
                    ID = cuisine.ID,
                    Name = cuisine.Name,
                    IsSelected = false
                });
            }
            return cuisinesViewModel;
        }

        //private void CreateTopPlaces(List<Attraction> attractions)
        //{
        //    TopPlacesViewModel = new TopPlacesViewModel();

        //    foreach (var attraction in attractions)
        //    {
        //        TopPlacesViewModel.TopPlacesLiked.Add(new CheckViewModel
        //        {
        //            ID = attraction.ID,
        //            Name = attraction.Name,
        //            IsSelected = false
        //        });
        //    }

        //    foreach (var attraction in attractions)
        //    {
        //        TopPlacesViewModel.TopPlacesDisliked.Add(new CheckViewModel
        //        {
        //            ID = attraction.ID,
        //            Name = attraction.Name,
        //            IsSelected = false
        //        });
        //    }
        //}
    }
}

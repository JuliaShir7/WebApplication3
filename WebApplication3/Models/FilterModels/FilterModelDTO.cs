using Microsoft.AspNetCore.DataProtection.KeyManagement;
using WebApplication3.EntityModels;
using WebApplication3.Interfaces;

namespace WebApplication3.Models.FilterModels
{
    public class FilterModelDTO
    {
        public string Group { get; set; }
        public string City { get; set; }
        public string Oldage { get; set; }
        public string Youngage { get; set; }
        public string Transport { get; set; }
        public DateTime TripStart { get; set; }
        public DateTime TripEnd { get; set; }


        public List<FoodRestriction> FoodRestrictions { get; set; }
        public List<Cuisine> CuisinesLiked { get; set; }
        public List<Cuisine> CuisinesDisliked { get; set; }
        public List<SubCategory> SubCategoriesLiked { get; set; }
        public List<SubCategory> SubCategoriesDisliked { get; set; }


        public List<Attraction> Attractions { get; set; }
        public List<Attraction> Cafes { get; set; }
        public List<Attraction> TopPlacesLiked { get; set; }
        public List<Attraction> TopPlacesDisliked { get; set; }

        public int[] Marks { get; set; }

        public TopPlacesViewModel TopPlacesViewModel { get; set; }

        public FilterModelDTO() { }
        public FilterModelDTO(string city, List<CheckViewModel> foodRestrictionsModel, CuisinesViewModel cuisinesModel, List<CategoriesViewModel> categoriesModel)
        {
            City = city;
            GetChoosedFoodRestrictions(foodRestrictionsModel);
            GetChoosedCuisines(cuisinesModel);
            GetChoosedSubCategories(categoriesModel);
        }

        public FilterModelDTO(string group, string city, string oldage, string youngage, string transport, DateTime tripStart, DateTime tripEnd,
            List<Attraction> attractions, List<Attraction> cafes, List<Attraction> topPlaces)
        {
            Group = group;
            City = city;
            Oldage = oldage;
            Youngage = youngage;
            Transport = transport;
            TripStart = tripStart;
            TripEnd = tripEnd;
            Cafes = cafes;
            Attractions = attractions;
            CreateTopPlaces(topPlaces);
        }

        public FilterModelDTO(string group, string city, string oldage, string youngage, string transport, DateTime tripStart, DateTime tripEnd,
           List<Attraction> attractions, List<Attraction> cafes, List<Attraction> topPlaces, List<SubCategory> subCategoriesLiked, List<Cuisine> cuisinesLiked)
        {
            Group = group;
            City = city;
            Oldage = oldage;
            Youngage = youngage;
            Transport = transport;
            TripStart = tripStart;
            TripEnd = tripEnd;
            Cafes = cafes;
            Attractions = attractions;
            CreateTopPlaces(topPlaces);
            SubCategoriesLiked = subCategoriesLiked;
            CuisinesLiked = cuisinesLiked;

        }


        public FilterModelDTO(string group, string oldage, string youngage, string transport, DateTime tripStart, DateTime tripEnd,
           List<Attraction> attractions, List<Attraction> cafes, TopPlacesViewModel topPlacesViewModel, int[] marks)
        {
            Group = group;
            Oldage = oldage;
            Youngage = youngage;
            Transport = transport;
            TripStart = tripStart;
            TripEnd = tripEnd;
            Cafes = cafes;
            Attractions = attractions;
            GetChoosedTopPlaces(topPlacesViewModel);
            Marks = marks;
        }




        //public FilterModelDTO(string group, string oldage, string youngage, string transport, DateTime tripStart, DateTime tripEnd)
        //{
        //    Group = group;
        //    Oldage = oldage;
        //    Youngage = youngage;
        //    Transport = transport;
        //    TripStart = tripStart;
        //    TripEnd = tripEnd;
        //}

        public FilterModelDTO(string group, string oldage, string youngage, string transport, DateTime tripStart, DateTime tripEnd)
        {
            Group = group;
            Oldage = oldage;
            Youngage = youngage;
            Transport = transport;
            TripStart = tripStart;
            TripEnd = tripEnd;
        }

        private void CreateTopPlaces(List<Attraction> attractions)
        {
            TopPlacesViewModel = new TopPlacesViewModel();

            foreach (var attraction in attractions)
            {
                TopPlacesViewModel.TopPlacesLiked.Add(new CheckViewModel
                {
                    ID = attraction.ID,
                    Name = attraction.Name,
                    IsSelected = false
                });
            }

            foreach (var attraction in attractions)
            {
                TopPlacesViewModel.TopPlacesDisliked.Add(new CheckViewModel
                {
                    ID = attraction.ID,
                    Name = attraction.Name,
                    IsSelected = false
                });
            }
        }

        private void GetChoosedFoodRestrictions(List<CheckViewModel> foodRestrictionsModel)
        {
            FoodRestrictions = new List<FoodRestriction>();

            foreach (var model in foodRestrictionsModel)
            {
                if (model.IsSelected)
                {
                    FoodRestrictions.Add(new FoodRestriction
                    {
                        ID = model.ID,
                        Name = model.Name
                    });
                }
            }
        }

        private void GetChoosedCuisines(CuisinesViewModel cuisinesModel)
        {
            CuisinesLiked = new List<Cuisine>();
            CuisinesDisliked = new List<Cuisine>();

            foreach (var liked in cuisinesModel.LikedCuisines)
            {
                if (liked.IsSelected)
                {
                    CuisinesLiked.Add(new Cuisine
                    {
                        ID = liked.ID,
                        Name = liked.Name
                    });
                }
            }

            foreach (var disliked in cuisinesModel.DislikedCuisines)
            {
                if (disliked.IsSelected)
                {
                    CuisinesDisliked.Add(new Cuisine
                    {
                        ID = disliked.ID,
                        Name = disliked.Name
                    });
                }
            }
        }

        private void GetChoosedSubCategories(List<CategoriesViewModel> categoriesModel)
        {
            SubCategoriesLiked = new List<SubCategory>();
            SubCategoriesDisliked = new List<SubCategory>();

            foreach (var model in categoriesModel)
            {
                foreach (var liked in model.SubCategoriesViewModel.LikedSubCategories)
                {
                    if (liked.IsSelected)
                    {
                        SubCategoriesLiked.Add(new SubCategory
                        {
                            ID = liked.ID,
                            Name = liked.Name
                        });
                    }
                }
            }

            foreach (var model in categoriesModel)
            {
                foreach (var disliked in model.SubCategoriesViewModel.DislikedSubCategories)
                {
                    if (disliked.IsSelected)
                    {
                        SubCategoriesDisliked.Add(new SubCategory
                        {
                            ID = disliked.ID,
                            Name = disliked.Name
                        });
                    }
                }
            }
        }

        private void GetChoosedTopPlaces(TopPlacesViewModel topPlacesViewModel)
        {
            TopPlacesLiked = new List<Attraction>();
            TopPlacesDisliked = new List<Attraction>();

            foreach (var liked in topPlacesViewModel.TopPlacesLiked)
            {
                if (liked.IsSelected)
                {
                    foreach(var attraction in Attractions)
                    {
                        if(liked.ID==attraction.ID)
                        {
                            TopPlacesLiked.Add(attraction);
                        }
                    }
                }
            }

            foreach (var disliked in topPlacesViewModel.TopPlacesDisliked)
            {
                if (disliked.IsSelected)
                {
                    foreach (var attraction in Attractions)
                    {
                        if (disliked.ID == attraction.ID)
                        {
                            TopPlacesDisliked.Add(attraction);
                        }
                    }
                }
            }
        }
    }
}

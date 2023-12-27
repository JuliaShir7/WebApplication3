using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using System.Diagnostics;
using WebApplication3.EntityModels;
using WebApplication3.Interfaces;
using WebApplication3.Models.FilterModels;

namespace WebApplication3.Services
{
    public class FilterService
    {

        public List<Attraction> GetTopTenPlaces(List<Attraction> attractions)
        {
            List<Attraction> topTen = new List<Attraction>();

            for (int i = 0; i < 10; i++)
            {
                topTen.Add(attractions[i]);
            }

            return topTen;
        }
    }
}

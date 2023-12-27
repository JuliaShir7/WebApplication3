using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WebApplication3.Helpers
{
    public static class JsonConverters
    {
        public static void ConvertToJson(string fileName, object o)
        {
            string jsonString = JsonConvert.SerializeObject(o, Formatting.Indented);
            StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8);
            sw.WriteLine(jsonString);
            sw.Close();
        }
        public static Dictionary<string, List<string>> GetAllRegionsWithCities()
        {
            string fileName = "citiesAndRegions.json";
            JObject jsonObject = JObject.Parse(System.IO.File.ReadAllText(fileName));
            var jsonString = jsonObject.ToString(Newtonsoft.Json.Formatting.None);
            //Console.Write(jsonString);
            var values = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonString);
            return values;
        }
        
        public static Dictionary<int, double> GetSpeeds()
        {
            string fileName = "speeds.json";
            JObject jsonObject = JObject.Parse(System.IO.File.ReadAllText(fileName));
            var jsonString = jsonObject.ToString(Newtonsoft.Json.Formatting.None);
            //Console.WriteLine(jsonString);
            var values = JsonConvert.DeserializeObject<Dictionary<int, double>>(jsonString);
            return values;
        }
        public static Dictionary<string, int> GetAgeGroups()
        {
            string fileName = "ageGroups.json";
            JObject jsonObject = JObject.Parse(System.IO.File.ReadAllText(fileName));
            var jsonString = jsonObject.ToString(Newtonsoft.Json.Formatting.None);
            //Console.WriteLine(jsonString);
            var values = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonString);
            return values;
        }
        public static List<string> GetCities()
        {
            var dict = GetAllRegionsWithCities();
            List<string> cities = new List<string>();
            foreach (var k in dict.Keys)
            {
                foreach (var c in dict[k])
                    cities.Add(c);
            }
            cities.Sort();
            return cities;
        }
    }
}

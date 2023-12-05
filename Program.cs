using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Data;
using static System.Net.WebRequestMethods;

namespace OpenWeatherMapProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me a city name, and I will return the temp if available. (ex. London)");

            string location = Console.ReadLine();

            var client = new HttpClient();

            var geoEncodingURL = $"https://api.openweathermap.org/data/2.5/weather?" +
                $"q={location}&units=imperial&appid=63a5a96f8a3bf27fc9cf588aba9e8d97";

            try
            {
                var geoEncodingResponse = client.GetStringAsync(geoEncodingURL).Result;
                double temp = double.Parse(JObject.Parse(geoEncodingResponse)["main"]["temp"].ToString());

                Console.WriteLine($"The current temperature in fahrenheit at {location} is: !---{temp}---!");
            }
            
            catch 
            {
                Console.WriteLine("Invalid input, whoops");
            }
            finally
            {
                Console.WriteLine("Tada!");
            }

        }
    }
}

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        var weatherService = new WeatherService(httpClient);
        // d3a9d988cbae80dc800440a4f8575d91
        Console.Write("Enter city name: ");
        var city = Console.ReadLine();

        string weatherInfo = await weatherService.GetWeatherAsync(city);

        Console.WriteLine(weatherInfo);
    }
}

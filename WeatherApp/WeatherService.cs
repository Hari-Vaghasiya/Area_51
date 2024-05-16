using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<string> GetWeatherAsync(string cityName)
    {
        // Replace 'your-api-key' with the actual API key from the weather service provider        
        string apiKey = "Get the your key";
        string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}";

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            WeatherData weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();

            return $"Weather in {cityName}: {weatherData.Main.Temp}°C, Feels Like: {weatherData.Main.Feels_like}°C, {weatherData.Weather[0].Description}";
        }
        catch (HttpRequestException)
        {
            return "Failed to retrieve weather data.";
        }
    }
}


public class MainData
{
    public double Temp { get; set; }
    public double Feels_like { get; set; }
    public double Temp_min { get; set; }
    public double Temp_max { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
}

public class WeatherData
{
    public required Weather[] Weather { get; set; }
    public MainData Main { get; set; }
}

public class Weather
{
    public string? Description { get; set; }
}
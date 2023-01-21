namespace WeatherReports;

interface IWeather // Interface for the weather
{
    double Temperature { get; set; } // Temperature
    string WeatherState { get; set; } // Weather state
    
    string GetWeather(); // Method that returns the weather state
}

public class Weather : IWeather // Class that contains the weather data
{
    private double _temperature; // Temperature
    private double Multiplier = 0.3; // Multiplier for the temperature
    public double Temperature { get => _temperature; set => _temperature = value; } // Temperature property
    public string WeatherState { get; set; } // Weather state property

    public string GetWeather() // Method that returns the weather state
    {
        return "";
    }


    public Weather(double longitude, double latitude) // Constructor that takes the longitude and latitude of the city
    {
        Random rnd = new Random(); // Random object
        _temperature = rnd.Next((int) (longitude * -Multiplier), (int) (longitude * Multiplier)); // Temperature is set to a random number between the longitude multiplied by the multiplier and the longitude multiplied by the multiplier
        
        var type = rnd.Next(0,3); // Random number between 0 and 3
        if ((WeatherType)type == WeatherType.Rainy && Temperature < 0) // If the weather type is rainy and the temperature is below 0, the weather state is set to snowy
        {
            WeatherState = "Snowy"; 
        }
        else 
        {
            WeatherState = ((WeatherType)type).ToString(); // Weather state is set to the weather type
        }

    }

}

abstract class GetWeatherClass : IWeather // Abstract class that contains the weather data
{
    public double Temperature { get; set; } // Temperature
    public string WeatherState { get; set; } // Weather state
    public abstract string GetWeather(); // Method that returns the weather state
}

class Sunny : GetWeatherClass // Class that contains the weather data
{
    public override string GetWeather() // Method that returns the weather state
    {
        return "Displaying  cities with sunny weather"; // Returns the weather state
    }
}

class Cloudy : GetWeatherClass
{
    public override string GetWeather()
    {
        return "Displaying cities with cloudy weather";
    }
}

class Rainy : GetWeatherClass
{
    public override string GetWeather()
    {
        return "Displaying cities with rainy weather";
    }
}

class Snowy : GetWeatherClass
{
    public override string GetWeather()
    {
        return "Displaying cities with snowy weather";
    }
}

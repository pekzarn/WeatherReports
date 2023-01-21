namespace WeatherReports;
public class Location 
{
    private Dictionary<int, Weather> WeatherData = new Dictionary<int, Weather>(); // Dictionary that contains the weather data for each day of the week
    
    public string Name { get; set; } // Name of the city
    private double Longitude { get; set; } // Longitude of the city
    private double Latitude { get; set; } // Latitude of the city
    
    
    public Location(string name, double longitude, double latitude) // Constructor that takes the name, longitude and latitude of the city
    {
        Name = name; 
        Longitude = longitude;
        Latitude = latitude;
        SimulateWeatherData();
    }

    private void SimulateWeatherData() // Method that simulates the weather data for each day of the week and adds it to the dictionary
    {
        for (int i = 0; i < 7; i++)
        {
            WeatherData.Add(i, new Weather(Longitude, Latitude));
        }
    }

    public void PrintWeatherDataByCity() // Method that prints the weather data for each day of the week
    {
        Console.WriteLine($"Weather data for {Name}: "); 
        foreach (KeyValuePair<int, Weather> item in WeatherData) // Loop that prints the weather data for each day of the week
        {
            Weather weather = item.Value;
            Console.WriteLine($"{((Weekdays)item.Key).ToString()} {weather.WeatherState} {weather.Temperature} "); // Prints the day of the week, the weather state and the temperature
        }
        
    }

    public void PrintWeatherData(string type) // Method that prints the weather data for each day of the week
    {
        Console.WriteLine($"Weather data for {Name}: ");
        foreach(KeyValuePair<int, Weather> item in WeatherData)
        {
            Weather weather = item.Value;
	
            if(weather.WeatherState.Equals(type))
            {
                Console.WriteLine($"{((Weekdays)item.Key).ToString()} {weather.WeatherState} {weather.Temperature} ");
            }
        }
    }

}

using System.Text.RegularExpressions;
namespace WeatherReports;

public static class App
{
    public static void Run() // This is the entry point of the program
    {
        while (true) // This is an infinite loop
        {
            UserInput(); // This is a method call
            ChooseWeatherOrCity();  // This is a method call
        }
    }
    
    private static void UserInput() // This is a method that checks if the user input is valid
    {
        Console.WriteLine("Please enter your username: ");
        string? username = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Please enter your password: ");
        string? password = Console.ReadLine();
        Console.Clear();

        if (username.Length < 1 || password.Length < 1) // This is a conditional statement
        {
            Console.WriteLine("Username and password must contain at least 1 character");
            UserInput();
        }
        else if (username.Length > 8 || password.Length > 8)
        {
            Console.WriteLine("Username and password must be 8 characters or less");
            UserInput();
        }
        else if (Regex.IsMatch(username, @"[^a-zA-Z0-9]") || Regex.IsMatch(password, @"[^a-zA-Z0-9]")) // This is a conditional statement using regex
        {
            Console.WriteLine("Username and password may only contain letters and numbers");
            UserInput();
        }
        else
        {
            Console.WriteLine("Username and password accepted!");
        }
    }
    
    private static void ChooseWeatherOrCity() //This is a method that lets the user choose between weather and city
    {
        Dictionary<int, Location> cities = new Dictionary<int, Location>(); // This is a dictionary that contains the cities
        cities.Add(0, new Location("Berlin", 13.404954, 52.520008));
        cities.Add(1, new Location("Paris", 48.856614, 2.3522219));
        cities.Add(2, new Location("Stockholm", 59.3293, 18.0686));
        
        Console.WriteLine();
        Console.WriteLine("[1] Press 1 to get weather reports for a city");
        Console.WriteLine("[2] Press 2 to check all places where a certain weather condition has been reported");
        Console.WriteLine("[Q] Press q to exit the program");
        string? input = Console.ReadLine();

        switch (input) // This is a switch statement that checks the user input
        {
            case "1":
                CityRequest(cities); // This is a method call that lets the user choose a specific city
                break;
            case "2":
                WeatherRequest(cities); // This is a method call that lets the user choose a specific weather condition
                break;
            case "q":
                Environment.Exit(0); // This is a method that exits the program
                break;
            default: // This is a default case
                Console.WriteLine("Please enter a valid number"); 
                break;
        }

    }
    
    private static void CityRequest(Dictionary<int, Location> cities) // This is a method that lets the user choose a specific city
    {
        Console.Clear();
        Console.WriteLine("Please type the city you would like to see the weather for");
        Console.WriteLine("[Q] Press q to go back to the main menu");
        
        for (int i = 0; i < cities.Count; i++) // This is a for loop that prints out the cities
        {
            Console.WriteLine($"{cities[i].Name}");
        }
        var city = Console.ReadLine();

        switch (city?.ToLower())
        {
            case "berlin":
                cities[0].PrintWeatherDataByCity(); // This is a method call that prints out the weather data for a specific city
                break;
            case "paris":
                cities[1].PrintWeatherDataByCity();
                break;
            case "stockholm":
                cities[2].PrintWeatherDataByCity();
                break;
            case "q":
                ChooseWeatherOrCity(); // This is a method call that takes the user back to the main menu
                break;
            default:
                Console.WriteLine("Please enter a valid City");
                Console.WriteLine();
                CityRequest(cities);
                break;
        }
        ChooseWeatherOrCity();
    }

    private static void WeatherRequest(Dictionary<int, Location> cities) // This is a method that lets the user choose a specific weather condition
    {
        Console.Clear();
        Console.WriteLine("Please select what type of weather you would like to see");
        Console.WriteLine("[1] Sunny");
        Console.WriteLine("[2] Cloudy");
        Console.WriteLine("[3] Rainy");
        Console.WriteLine("[4] Snowy");
        Console.WriteLine("[Q] Press q to go back to the main menu");
        
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Sunny sunny = new Sunny(); // This creates object that contains the weather condition
                Console.WriteLine($"{sunny.GetWeather()}"); // This is a method call that prints out the weather condition
                cities[0].PrintWeatherData("Sunny"); // This is a method call that prints out the weather data for a specific weather condition
                cities[1].PrintWeatherData("Sunny");
                cities[2].PrintWeatherData("Sunny");
                break;
            case "2":
                Cloudy cloudy = new Cloudy();
                Console.WriteLine($"{cloudy.GetWeather()}");
                cities[0].PrintWeatherData("Cloudy");
                cities[1].PrintWeatherData("Cloudy");
                cities[2].PrintWeatherData("Cloudy");
                break;
            case "3":
                Rainy rainy = new Rainy();
                Console.WriteLine($"{rainy.GetWeather()}");
                cities[0].PrintWeatherData("Rainy");
                cities[1].PrintWeatherData("Rainy");
                cities[2].PrintWeatherData("Rainy");
                break;
            case "4":
                Snowy snowy = new Snowy();
                Console.WriteLine($"{snowy.GetWeather()}");
                cities[0].PrintWeatherData("Snowy");
                cities[1].PrintWeatherData("Snowy");
                cities[2].PrintWeatherData("Snowy");
                break;
            case "q":
                ChooseWeatherOrCity();
                break;
            default:
                Console.WriteLine("Please select a valid weather type");
                Console.WriteLine();
                CityRequest(cities);
                break;
        }
        ChooseWeatherOrCity();
    }

}

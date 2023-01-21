namespace WeatherReports;

public class User
{
    public User(string userName, string password) // Constructor
    {
        UserName = userName;
        Password = password;
    }

    private string UserName { get; set; } // Username
    private string Password { get; set; } // Password

}
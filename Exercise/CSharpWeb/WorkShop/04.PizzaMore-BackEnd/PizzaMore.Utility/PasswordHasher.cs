namespace PizzaMore.Utility
{
    public class PasswordHasher
    {
        public static string Hash(string password)
        {
            return "SECRET" + password;
        }
    }
}
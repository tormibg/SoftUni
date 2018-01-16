using System.Linq;
using CarDealer.Data;
using CarDealer.Models.EntityModels;
using Microsoft.Ajax.Utilities;

namespace CarDealer.App.Security
{
    public class AuthenticationManager
    {
        private static CarDealerContext context = new CarDealerContext();

        public static bool IsAuthenticated(string httpCookieValue)
        {
            if (context.Logins.Any(login => login.SessionId == httpCookieValue && login.IsActive))
            {
                return true;
            }

            return false;
        }

        public static User GetAuthenticatedUser(string cookieValue)
        {
            var login = context.Logins.FirstOrDefault(log => log.SessionId == cookieValue && log.IsActive);
            var user = login?.User;
            return user;
        }
    }
}
using System.Linq;
using CameraBazaar.Models.EntityModels;
using CameraBazzar.Data;

namespace CameraBazaar.App.Security
{
    public class AuthenticationManager
    {
        private CameraBazaarContext context;

        public AuthenticationManager()
        {
            this.context = new CameraBazaarContext();
        }

        public bool IsAuthenticated(string sessionId)
        {
            if (sessionId == null)
            {
                return false;
            }

            if (this.context.Logins.Any(login => login.SessionId == sessionId && login.IsActive))
            {
                return true;
            }

            return false;
        }

        public User GetAuthenticatedUser(string sessionId)
        {
            var firstOrDefault = this.context.Logins.FirstOrDefault(login => login.SessionId == sessionId && login.IsActive);
            if (firstOrDefault != null)
            {
                var authenticatedUser = firstOrDefault.User;
                if (authenticatedUser != null)
                    return authenticatedUser;
            }

            return null;
        }

        public void Logout(string sessioId)
        {
            Login login = this.context.Logins.FirstOrDefault(login1 => login1.SessionId == sessioId);
	        login.User.LastLoginTime = login.LoginStamp;
            login.IsActive = false;
            context.SaveChanges();
        }
    }
}
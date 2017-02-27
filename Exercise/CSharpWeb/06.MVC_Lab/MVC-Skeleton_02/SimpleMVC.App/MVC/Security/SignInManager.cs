using System.Linq;
using SimpleHttpServer.Models;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.MVC.Security
{
    public class SignInManager
    {
        private readonly IDbIdentityContext dbContex;

        public SignInManager(IDbIdentityContext contex)
        {
            this.dbContex = contex;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            if (session == null)
            {
                return false;
            }
           
                var logins = dbContex.Logins.FirstOrDefault(l => l.SessionId == session.Id);
                if (logins != null && logins.IsActive == true)
                {
                    return true;
                }
            
            return false;
        }

        public void LogOut(HttpSession session)
        {
            var logins = dbContex.Logins.FirstOrDefault(l => l.SessionId == session.Id);
            logins.IsActive = false;
            dbContex.SaveChanges();
        }
    }
}
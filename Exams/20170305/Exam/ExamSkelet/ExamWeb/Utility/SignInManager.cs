using Ninject;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using SoftUniStore.App.Data.Contracts;
using SoftUniStore.App.DepedencyContainer;
using SoftUniStore.App.Model;

namespace SoftUniStore.App.Utility
{
    public class SignInManager
    {
        private readonly IUnitOfWork context;

        public SignInManager()
        {
            this.context = DependencyKernel.Kernel.Get<IUnitOfWork>();
        }

        public bool IsAuthenticated(HttpSession session)
        {
            var user  = this.context.Logins.FirstOrDefault(l => l.SessionId == session.Id && l.IsActive)?.User;

            if (user != null)
            {
                ViewBag.Bag["fullname"] = user.Fullname;
                return true;
            }

            return false;
        }

        public User GetAuthenticatedUser(HttpSession session)
        {
            User user = this.context.Logins.FirstOrDefault(l => l.SessionId == session.Id && l.IsActive)?.User;

            if (user != null)
            {
                ViewBag.Bag["fullname"] = user.Fullname;
            }

            return user;
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            ViewBag.Bag["fullname"] = null;
            Login currentLogin = this.context.Logins.FirstOrDefault(login => login.SessionId == sessionId);
            currentLogin.IsActive = false;
            this.context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
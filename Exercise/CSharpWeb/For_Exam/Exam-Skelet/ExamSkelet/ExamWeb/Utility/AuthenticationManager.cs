using System;
using ExamWeb.Data.Contracts;
using ExamWeb.DepedencyContainer;
using ExamWeb.Model;
using Ninject;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;

namespace ExamWeb.Utility
{
    public static class AuthenticationManager
    {
        public static User GetAuthenticatedUser(string sessionId)
        {
            IUnitOfWork Context = DependencyKernel.Kernel.Get<IUnitOfWork>();

            User user = Context.Logins.FirstOrDefault(l => l.SessionId == sessionId && l.IsActive)?.User;
            if (user != null)
            {
                ViewBag.Bag["username"] = user.Username;
            }

            return user;
        }

        public static bool IsAuthenticated(string sessionId)
        {
            IUnitOfWork Context = DependencyKernel.Kernel.Get<IUnitOfWork>();

            return Context.Logins.Any(l => l.SessionId == sessionId && l.IsActive);
        }

        internal static void Logout(HttpResponse response, string sessionId)
        {
            IUnitOfWork Context = DependencyKernel.Kernel.Get<IUnitOfWork>();
            ViewBag.Bag["username"] = null;
            Login currentLogin = Context.Logins.FirstOrDefault(login => login.SessionId == sessionId);
            currentLogin.IsActive = false;
            Context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
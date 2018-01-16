using Ninject;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using SoftUniStore.App.Data.Contracts;
using SoftUniStore.App.DepedencyContainer;
using SoftUniStore.App.Model;

namespace SoftUniStore.App.Utility //NOT USE
{
    //public static class AuthenticationManager
    //{
    //    public static User GetAuthenticatedUser(string sessionId)
    //    {
    //        IUnitOfWork Context = DependencyKernel.Kernel.Get<IUnitOfWork>();

    //        User user = Context.Logins.FirstOrDefault(l => l.SessionId == sessionId && l.IsActive)?.User;
    //        if (user != null)
    //        {
    //            ViewBag.Bag["fullname"] = user.Fullname;
    //        }

    //        return user;
    //    }

    //    public static bool IsAuthenticated(string sessionId)
    //    {
    //        IUnitOfWork Context = DependencyKernel.Kernel.Get<IUnitOfWork>();

    //        return Context.Logins.Any(l => l.SessionId == sessionId && l.IsActive);
    //    }

    //    internal static void Logout(HttpResponse response, string sessionId)
    //    {
    //        IUnitOfWork Context = DependencyKernel.Kernel.Get<IUnitOfWork>();
    //        ViewBag.Bag["fullname"] = null;
    //        Login currentLogin = Context.Logins.FirstOrDefault(login => login.SessionId == sessionId);
    //        currentLogin.IsActive = false;
    //        Context.SaveChanges();

    //        var session = SessionCreator.Create();
    //        var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
    //        response.Header.AddCookie(sessionCookie);
    //    }
    //}
}
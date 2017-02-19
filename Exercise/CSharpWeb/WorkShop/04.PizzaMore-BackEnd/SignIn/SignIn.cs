using System;
using System.Collections.Generic;
using System.Linq;
using PizzaMore.Data;
using PizzaMore.Utility;

namespace SignIn
{
    class SignIn
    {
        public static IDictionary<string, string> RequestParameters;
        public static readonly Header Header = new Header();

        static void Main()
        {
            if (WebUtil.IsPost())
            {
                LogIn();
            }

            ShowGetPage();
        }

        private static void LogIn()
        {
            RequestParameters = WebUtil.RetrievePostParameters();
            string email = RequestParameters["email"];
            string password = RequestParameters["password"];
            string hashedPass = PasswordHasher.Hash(password);
            using (var pizzaContext = new PizzaMoreContext())
            {
                var user = pizzaContext.Users.FirstOrDefault(u => u.Email == email);
                if (user.Password == hashedPass)
                {
                    var session = new Session()
                    {
                        Id = new Random().Next().ToString(),
                        User = user
                    };
                    if (user != null)
                    {
                        Header.AddCookie(new Cookie(Constants.SessionIdKey, session.Id));
                    }
                    pizzaContext.Sessions.Add(session);
                    pizzaContext.SaveChanges();
                }
            }
        }

        private static void ShowGetPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.SignInHtml);
        }
    }
}

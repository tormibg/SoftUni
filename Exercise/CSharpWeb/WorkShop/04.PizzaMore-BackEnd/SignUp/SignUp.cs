using System.Collections.Generic;
using PizzaMore.Data;
using PizzaMore.Utility;

namespace SignUp
{
    class SignUp
    {
        public static IDictionary<string, string> RequestParameters;
        public static readonly Header Header = new Header();

        static void Main(string[] args)
        {
            if (WebUtil.IsPost())
            {
                RegisterUser();
            }

            ShowGetPage();
        }

        private static void RegisterUser()
        {
            RequestParameters = WebUtil.RetrievePostParameters();
            var email = RequestParameters["email"];
            var password = RequestParameters["password"];
            var user = new User()
            {
                Email = email,
                Password = PasswordHasher.Hash(password)
            };
            using (var userContext = new PizzaMoreContext())
            {
                userContext.Users.Add(user);
                userContext.SaveChanges();
            }
        }

        private static void ShowGetPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.SignUpHtml);
        }
    }
}

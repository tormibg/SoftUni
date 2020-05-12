using iRunes.Services;
using iRunes.ViewModels.Users;
using SIS.HTTP;
using SIS.HTTP.Response;
using SIS.MvcFramework;

namespace iRunes.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public HttpResponse Login()
        {
            return this.View();
        }
        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = usersService.GetUserId(input.Username, input.Password);
            if (userId != null)
            {
                this.SignIn(userId);
                return new RedirectResponse("/");
            }

            return this.Redirect("/Users/Login");
        }
        public HttpResponse Register()
        {
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.usersService.EmailExists(input.Email) || this.usersService.UserNameExists(input.Username))
            {
                return this.Error("Username or email is exists");
            }
            if (input.Password != input.confirmPassword)
            {
                return this.Error("Password should match.");
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Error("Email is empty");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password must be at least 6 characters or at most 20");
            }
            if (input.Username.Length < 4 || input.Username.Length > 20)
            {
                return this.Error("Username must be at least 4 characters or at most 20");
            }

            this.usersService.Register(input.Username, input.Password, input.Email);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse LogOut()
        {
            this.LogOut();
            return this.Redirect("/");
        }
    }
}

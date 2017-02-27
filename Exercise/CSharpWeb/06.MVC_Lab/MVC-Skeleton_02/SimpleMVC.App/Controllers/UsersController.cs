using System.Collections.Generic;
using System.Linq;
using SimpleHttpServer.Models;
using SimpleMVC.App.BindingModels;
using SimpleMVC.App.Data;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Attributes;
using SimpleMVC.App.MVC.Controllers;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.MVC.Security;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Controllers
{
    public class UsersController : Controller
    {
        private SignInManager signInManager;

        public UsersController()
        {
            signInManager = new SignInManager(new NotesAppContext());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Password = model.Password
            };
            using (var context = new NotesAppContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model, HttpSession session, HttpResponse response)
        {
            string userName = model.Username;
            string password = model.Password;
            string sessionId = session.Id;
            using (var contex = new NotesAppContext())
            {
                var user = contex.Users.FirstOrDefault(u => u.Username == userName && u.Password == password);
                if (user != null)
                {
                    contex.Logins.Add(new Login()
                    {
                        SessionId = sessionId,
                        User = user,
                        IsActive = true
                    });
                    contex.SaveChanges();
                    Redirect(response, @"/home/index");
                    return null;
                }
            }
            return this.View();
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session)
        {
            signInManager.LogOut(session);
            return this.View("Home", "Index");
        }

        [HttpGet]
        public IActionResult<IEnumerable<AllUsersViewModel>> All(HttpSession session, HttpResponse response)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }
            List<User> userList = null;
            using (var context = new NotesAppContext())
            {
                userList = context.Users.ToList();
            }

            var viewModel = new List<AllUsersViewModel>();
            foreach (var user in userList)
            {
                viewModel.Add(new AllUsersViewModel()
                {
                    Username = user.Username,
                    Id = user.Id
                });
            }

            return this.View(viewModel.AsEnumerable());
        }

        //[HttpGet]
        //public IActionResult<AllUserNamesViewModel> All()
        //{
        //    List<string> usernameList = null;
        //    using (var context = new NotesAppContext())
        //    {
        //        usernameList = context.Users.Select(x => x.Username).ToList();
        //    }

        //    var viewModel = new AllUserNamesViewModel()
        //    {
        //        Usernames = usernameList
        //    };
        //    return View(viewModel);
        //}

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var context = new NotesAppContext())
            {
                var user = context.Users.Find(id);
                var viewModel = new UserProfileViewModel()
                {
                    UserId = id,
                    Username = user.Username,
                    Notes = user.Notes.Select(n => new NoteViewModel() { Content = n.Content, Title = n.Title })
                };
                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new NotesAppContext())
            {
                var user = context.Users.Find(model.UserId);
                var note = new Note()
                {
                    Title = model.Title,
                    Content = model.Content
                };
                user.Notes.Add(note);
                context.SaveChanges();
            }
            return Profile(model.UserId);
        }

        [HttpGet]
        public IActionResult<GreetViewModel> Greet(HttpSession session)
        {
            var viewModel = new GreetViewModel()
            {
                SessionId = session.Id
            };
            return this.View(viewModel);
        }
    }
}
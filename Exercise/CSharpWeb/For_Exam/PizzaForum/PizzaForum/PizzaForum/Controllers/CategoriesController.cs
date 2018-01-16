namespace PizzaForum.Controllers
{
    using BindingModels;
    using Models;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
    using Utilities;
    using ViewModels;

    public class CategoriesController : Controller
    {
        private readonly CategoriesService _service;

        public CategoriesController()
        {
            this._service = new CategoriesService();
        }

        [HttpGet]
        public IActionResult<AllViewModel> All(HttpSession session, HttpResponse response)
        {
            User activeUser = this.GetAuthenticatedUser(response, session);

            AllViewModel viewModel = this._service.GetAllViewModel(activeUser);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult New(HttpResponse response, HttpSession session)
        {
            this.GetAuthenticatedUser(response, session);
            return this.View();
        }

        [HttpPost]
        public void New(HttpResponse response, HttpSession session, NewCategoryBindingModel bind)
        {
            this.GetAuthenticatedUser(response, session);

            if (!this._service.IsNewCategoryValid(bind))
            {
                this.Redirect(response, "/categories/new");
            }

            this._service.AddNewCategory(bind);
            this.Redirect(response, "/categories/all");
        }

        [HttpGet]
        public void Delete(HttpResponse response, HttpSession session, int id)
        {
            this.GetAuthenticatedUser(response, session);

            this._service.DeleteCategory(id);
            this.Redirect(response, "/categories/all");
        }

        [HttpGet]
        public IActionResult<EditCategoryViewModel> Edit
            (HttpResponse response, HttpSession session, int id)
        {
            User user = this.GetAuthenticatedUser(response, session);
            if (user == null)
                return null;

            EditCategoryViewModel viewModel = this._service.GetEditCategoryVM(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public void Edit
             (HttpResponse response, HttpSession session, EditCategoryBM bind)
        {
            User user = this.GetAuthenticatedUser(response, session);
            if (user == null)
            {
                return;
            }

            this._service.EditCategoryEntity(bind);
            this.Redirect(response, "/categories/all");
        }

        public IActionResult<IEnumerable<TopicVM>> Topics(HttpSession session, string categoryName)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);

            IEnumerable<TopicVM> topics = this._service.GetCategoryTopicsVms(categoryName);
            return this.View(topics);
        }

        private User GetAuthenticatedUser(HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
            }

            return activeUser;
        }
    }
}

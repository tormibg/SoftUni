using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.App.Security;
using CarDealer.Models.BindingModels.Sale;
using CarDealer.Models.BindingModels.Supplier;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;
using CarDealer.Models.ViewModels.Supplier;
using CarDealer.Services;

namespace CarDealer.App.Controllers
{
    [RoutePrefix("suppliers")]
    public class SuppliersController : Controller
    {
        private SuppliersService service;

        public SuppliersController()
        {
            this.service = new SuppliersService();
        }

        [HttpGet]
        [Route("{type:regex(local|importers)?}")]
        public ActionResult All(string type)
        {
            var cookie = this.Request.Cookies.Get("sessionId");

            if (cookie != null && !AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                IEnumerable<AllSupplierVM> viewModel = this.service.GetSuppliersByType(type);
                return this.View(viewModel);
            }

            User user = AuthenticationManager.GetAuthenticatedUser(cookie.Value);
            ViewBag.Username = user.Username;
            IEnumerable<SupplierImportVM> vm = this.service.GetAllSuppliersByTypeForUsers(type);
            return this.View("AllSuppliersForUser", vm);
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            SupplierImportVM viewModel = this.service.GetSupplierById(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id, Name, IsImporter")] SupplierEditBM bind)
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (ModelState.IsValid)
            {
                User user = AuthenticationManager.GetAuthenticatedUser(cookie.Value);
                this.service.EditSupplier(bind, user.Id);
                return this.RedirectToAction("All");
            }
            SupplierImportVM viewModel = this.service.GetSupplierById(bind.Id);
            return this.View(viewModel);
        }

        [HttpGet]
        [Route("Add")]
        public ActionResult Add()
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }


            return this.View(new SupplierAddVm());
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add([Bind(Include = "Name, IsImporter")] SupplierAddBM bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }

            if (ModelState.IsValid)
            {
                User user = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);
                this.service.AddSupplier(bind, user.Id);
                return this.RedirectToAction("All");
            }
            return this.View();
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }
            SupplierDeleteVM viewModel = this.service.GetDeleteSupplier(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        public ActionResult Delete([Bind(Include = "Id")] SupplierDeleteBM bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("All");
            }
            if (!this.ModelState.IsValid)
            {
                SupplierDeleteVM viewModel = this.service.GetDeleteSupplier(bind.Id);
                return this.View(viewModel);
            }
            User user = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);
            this.service.DeleteSupplier(bind.Id, user.Id);
            return this.RedirectToAction("All");
        }
    }
}
using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.Models.BindingModels;
using CarDealer.Models.ViewModels;
using CarDealer.Services;

namespace CarDealer.App.Controllers
{
    [RoutePrefix("customers")]
    public class CustomersController : Controller
    {
        private readonly CustomersService service;

        public CustomersController()
        {
            this.service = new CustomersService();
        }

        [HttpGet]
        [Route("all/{order=ascending:regex(ascending|descending)}")]
        public ActionResult All(string order)
        {
            IEnumerable<AllCustomerVM> viewModels = this.service.GetAllOrderedCustomers(order);

            return this.View(viewModels);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult About(int id)
        {
            AboutCustomerVM viewModel = this.service.GetCustomerById(id);

            return View(viewModel);
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Name,BirthDate")] AddCustomerBM bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddCustomer(bind);
                return this.RedirectToAction("All", new { order = "ascending" });
            }

            return this.View();
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            EditCustomerVM viewModel = this.service.GetCustomerEditVM(id);

            return View(viewModel);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id,Name,BirthDate")] EditCustomerBM bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditCustomer(bind);
                return this.RedirectToAction("All", new { order = "ascending" });
            }

            return this.View();
        }
    }
}
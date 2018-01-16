using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.App.Filters;
using CarDealer.App.Security;
using CarDealer.Models.BindingModels;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;
using CarDealer.Models.ViewModels.Car;
using CarDealer.Services;

namespace CarDealer.App.Controllers
{
    [RoutePrefix("cars")]
    public class CarsController : Controller
    {
        private readonly CarsService service;

        public CarsController()
        {
            this.service = new CarsService();
        }

        [HttpGet]
        [Route("add")]
        [Timer]
        public ActionResult Add()
        {
            CarAddVm viewModel = this.service.GetCarAddModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Route("add")]
        [Timer]
        public ActionResult Add([Bind(Include = "Make, Model, TravelledDistance, parts")] AddCarBM bind)
        {
            var httpCookie = this.Request.Cookies.Get("sessionId");
            if (httpCookie == null || !AuthenticationManager.IsAuthenticated(httpCookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }

            if (ModelState.IsValid)
            {
                User user = AuthenticationManager.GetAuthenticatedUser(httpCookie.Value);
                this.service.AddCar(bind, user.Id);
                return this.RedirectToAction("all");
            }
            return this.View();
        }

        [HttpGet]
        [Route("{make?}")]
        [Log]
        public ActionResult All(string make)
        {
            IEnumerable<CarsByMakeVM> viewModes = this.service.GetCarsByMake(make);

            return this.View(viewModes);
        }

        [HttpGet]
        [Route("{id:int}/parts")]
        public ActionResult About(int id)
        {
            AboutCarVM viewModel = service.GetCarAndPartsById(id);

            return View(viewModel);
        }

        [HttpGet]
        [Route("details/{id}")]
        [Timer]
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "OutOfRangeError")]
        [Log]
        public ActionResult Details(int id)
        {
            Car viewModel = this.service.GetCarViewMoldes(id);
            return this.View(viewModel);
        }
    }
}
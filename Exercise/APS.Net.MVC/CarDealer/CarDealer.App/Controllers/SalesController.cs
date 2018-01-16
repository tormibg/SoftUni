using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.App.Security;
using CarDealer.Models.BindingModels.Sale;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels.Sale;
using CarDealer.Services;

namespace CarDealer.App.Controllers
{
    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        private SalesService service;

        public SalesController()
        {
            this.service = new SalesService();
        }

        [HttpGet]
        [Route]
        public ActionResult All()
        {
            IEnumerable<AllSalesVM> viewModel = this.service.GetAllSales();
            return View(viewModel);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult About(int id)
        {
            AllSalesVM viewModel = this.service.GetSalesById(id);

            return View(viewModel);
        }

        [HttpGet]
        [Route("discounted/{percent?}")]
        public ActionResult Discounted(double? percent)
        {
            IEnumerable<AllSalesVM> viewModel = this.service.GetDiscountedSales(percent);
            return View(viewModel);
        }

        [HttpGet]
        [Route("Add")]
        public ActionResult Add()
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }
            SalesAddVM viewModels = this.service.GetSalesVM();

            return this.View(viewModels);
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add([Bind(Include = "CustomersId, CarsId, Discount")] SaleAddBM bind)
        {
            if (ModelState.IsValid)
            {
                SaleAddConfirmationVM viewModel = this.service.GetAddConfirmationVM(bind);
                return this.RedirectToAction("AddConfirmation", "Sales", viewModel);
            }

            SalesAddVM viewModels = this.service.GetSalesVM();

            return this.View(viewModels);
        }

        [HttpGet]
        [Route("AddConfirmation")]
        public ActionResult AddConfirmation(SaleAddConfirmationVM vm)
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }
            return this.View(vm);
        }

        [HttpPost]
        [Route("AddConfirmation")]
        public ActionResult AddConfirmation(SaleAddBM bind)
        {
            var cookie = this.Request.Cookies.Get("sessionId");
            if (cookie == null || !AuthenticationManager.IsAuthenticated(cookie.Value))
            {
                return this.RedirectToAction("Login", "Users");
            }
            User user = AuthenticationManager.GetAuthenticatedUser(cookie.Value);
            this.service.AddSale(bind, user.Id);
            return this.RedirectToAction("All");
        }
    }
}
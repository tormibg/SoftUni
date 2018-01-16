using System.Collections.Generic;
using System.Web.Mvc;
using CarDealer.Models.BindingModels;
using CarDealer.Models.ViewModels;
using CarDealer.Models.ViewModels.Part;
using CarDealer.Models.ViewModels.Supplier;
using CarDealer.Services;

namespace CarDealer.App.Controllers
{
    [RoutePrefix("parts")]
    public class PartsController : Controller
    {
        private readonly PartsServices service;

        public PartsController()
        {
            this.service = new PartsServices();
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            PartAddVm suppliers = this.service.GetAllSuppliers();

            return View(suppliers);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([Bind(Include = "Name, Price, Quantity, Id")] AddPartsBM bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddPart(bind);
                return this.RedirectToAction("All");
            }

            IEnumerable<AddSupplierVM> suppliers = this.service.GetSupplierVM();

            return View(suppliers);

        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<AllPartsVM> viewModels = this.service.GetAllParts();

            return View(viewModels);
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var viewModel = this.service.GetDeleteVM(id);
            return View(viewModel);
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        public ActionResult Delete([Bind(Include = "PartId")] DeletePartBM bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeletePart(bind);
                return this.RedirectToAction("All");
            }

            var viewModels = this.service.GetDeleteVM(bind.PartId);
            return View(viewModels);
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var viewModel = this.service.GetEditParts(id);
            return View(viewModel);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id, Price, Quantity")] EditPartBM bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditParts(bind);
                return this.RedirectToAction("All");
            }

            var viewModel = this.service.GetEditParts(bind.Id);
            return View(viewModel);
        }
    }
}
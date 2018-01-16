
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.BindingModels;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;
using CarDealer.Models.ViewModels.Part;
using CarDealer.Models.ViewModels.Supplier;

namespace CarDealer.Services
{
    public class PartsServices : Service
    {
        public PartAddVm GetAllSuppliers()
        {
            var suppliers = this.Context.Suppliers.Select(vms => new AddSupplierVM()
            {
                Id = vms.Id,
                Name = vms.Name
            });

            PartAddVm parts = new PartAddVm();
            parts.SupplierAddPartVms = suppliers;
            return parts;
        }

        public void AddPart(AddPartsBM bind)
        {
            var part = Mapper.Map<AddPartsBM, Part>(bind);
            var supplier = this.Context.Suppliers.Find(bind.Id);
            part.Supplier = supplier;
            if (bind.Quantity == 0)
            {
                bind.Quantity = 1;
            }
            this.Context.Parts.Add(part);
            this.Context.SaveChanges();
        }

        public IEnumerable<AllPartsVM> GetAllParts()
        {
            var parts = this.Context.Parts;
            var viewModels = Mapper.Map<IEnumerable<Part>, IEnumerable<AllPartsVM>>(parts);
            return viewModels;
        }

        public DeletePartVM GetDeleteVM(int id)
        {
            var part = this.Context.Parts.Find(id);
            var viewModel = Mapper.Map<Part, DeletePartVM>(part);

            return viewModel;
        }

        public void DeletePart(DeletePartBM bind)
        {
            var part = this.Context.Parts.Find(bind.PartId);
            this.Context.Parts.Remove(part);
            this.Context.SaveChanges();
        }

        public EditPartVM GetEditParts(int id)
        {
            var part = this.Context.Parts.Find(id);
            var viewModel = Mapper.Map<Part, EditPartVM>(part);
            return viewModel;
        }

        public void EditParts(EditPartBM bind)
        {
            var part = this.Context.Parts.Find(bind.Id);
            if (part != null)
            {
                part.Price = bind.Price;
                part.Quantity = bind.Quantity;
                this.Context.SaveChanges();
            }
        }

        public IEnumerable<AddSupplierVM> GetSupplierVM()
        {
            var suppliers = this.Context.Suppliers.Select(vms => new AddSupplierVM()
            {
                Id = vms.Id,
                Name = vms.Name
            });

            return suppliers;
        }
    }
}
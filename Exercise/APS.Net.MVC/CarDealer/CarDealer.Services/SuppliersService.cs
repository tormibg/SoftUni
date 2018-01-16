using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.BindingModels.Supplier;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels.Supplier;

namespace CarDealer.Services
{
    public class SuppliersService : Service
    {
        public IEnumerable<AllSupplierVM> GetSuppliersByType(string type)
        {
            IEnumerable<Supplier> suppliers;
            if (type.ToLower() == "local")
            {
                suppliers = this.Context.Suppliers.Where(s => !s.IsImporter);
            }
            else if (type.ToLower() == "importers")
            {
                suppliers = this.Context.Suppliers.Where(s => s.IsImporter);
            }
            else
            {
                throw new ArgumentException("The argument must be local or importers");
            }

            var viewModel = Mapper.Instance.Map<IEnumerable<Supplier>, IEnumerable<AllSupplierVM>>(suppliers);

            return viewModel;
        }

        public IEnumerable<SupplierImportVM> GetAllSuppliersByTypeForUsers(string type)
        {
            IEnumerable<Supplier> suppliers = this.GetSupplierModelsByType(type);

            var viewModel = Mapper.Instance.Map<IEnumerable<Supplier>, IEnumerable<SupplierImportVM>>(suppliers);

            return viewModel;
        }

        private IEnumerable<Supplier> GetSupplierModelsByType(string type)
        {
            IEnumerable<Supplier> suppliersWanted;
            if (type == null)
            {
                suppliersWanted = this.Context.Suppliers;
            }
            else if (type.ToLower() == "local")
            {
                suppliersWanted = this.Context.Suppliers.Where(supplier => !supplier.IsImporter);
            }
            else if (type.ToLower() == "importers")
            {
                suppliersWanted = this.Context.Suppliers.Where(supplier => supplier.IsImporter);
            }
            else
            {
                throw new ArgumentException("Invalid argument for the type of the supplier!");
            }

            return suppliersWanted;
        }

        public SupplierImportVM GetSupplierById(int id)
        {
            var supplier = this.Context.Suppliers.Find(id);
            var viewModel = Mapper.Map<Supplier, SupplierImportVM>(supplier);
            return viewModel;
        }

        public void EditSupplier(SupplierEditBM bind, int userId)
        {
            var supllier = this.Context.Suppliers.Find(bind.Id);
            supllier.IsImporter = bind.IsImporter == "on";
            supllier.Name = bind.Name;
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Edit, "suplliers");
        }

        public void AddSupplier(SupplierAddBM bind, int userId)
        {
            var supplier = Mapper.Map<SupplierAddBM, Supplier>(bind);
            this.Context.Suppliers.Add(supplier);
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Add, "suplliers");
        }

        public void DeleteSupplier(int id, int userId)
        {
            Supplier supplier = this.Context.Suppliers.Find(id);
            this.Context.Suppliers.Remove(supplier);
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Delete, "suplliers");
        }

        public SupplierDeleteVM GetDeleteSupplier(int id)
        {
            Supplier supplier = this.Context.Suppliers.Find(id);
            var viewModel = Mapper.Map<Supplier, SupplierDeleteVM>(supplier);
            return viewModel;
        }
    }
}
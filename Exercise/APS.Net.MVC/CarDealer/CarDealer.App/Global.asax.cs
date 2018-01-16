using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CarDealer.Models.BindingModels;
using CarDealer.Models.BindingModels.Supplier;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;
using CarDealer.Models.ViewModels.Sale;
using CarDealer.Models.ViewModels.Supplier;

namespace CarDealer.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            //expression.CreateMap<Supplier, AllSupplierVM>().ForMember(vm => vm.NumberOfPartsToSupply, configurationExpression => configurationExpression.MapFrom(supplier => supplier.Parts.Count));

            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Customer, AllCustomerVM>();
                expression.CreateMap<Car, CarsByMakeVM>();
                expression.CreateMap<Supplier, AllSupplierVM>();
                expression.CreateMap<Part, PartsVM>();
                expression.CreateMap<Sale, AllSalesVM>()
                    .ForMember(vm => vm.Price, ce => ce.MapFrom(sale => sale.Car.Parts.Sum(p => p.Price)));
                expression.CreateMap<AddCustomerBM, Customer>();
                expression.CreateMap<Customer, EditCustomerVM>();
                expression.CreateMap<EditCustomerBM, Customer>();
                expression.CreateMap<AddPartsBM, Part>();
                expression.CreateMap<Part, AllPartsVM>();
                expression.CreateMap<Part, DeletePartVM>();
                expression.CreateMap<Part, EditPartVM>();
                expression.CreateMap<AddCarBM, Car>();
                expression.CreateMap<UserRegisterVM, User>();
                expression.CreateMap<Supplier, SupplierImportVM>();
                expression.CreateMap<Car, SalesAddCarsVM>().ForMember(vm => vm.MakeAndModel, configurationExpression => configurationExpression.MapFrom(car => $"{car.Make} {car.Model}"));
                expression.CreateMap<Customer, SalesAddCustomersVM>();
                expression.CreateMap<SupplierAddBM, Supplier>();
                expression.CreateMap<Supplier, SupplierDeleteVM>();
            });
        }
    }
}

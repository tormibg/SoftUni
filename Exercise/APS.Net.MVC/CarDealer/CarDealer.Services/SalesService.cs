using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.BindingModels.Sale;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels.Sale;

namespace CarDealer.Services
{
    public class SalesService : Service
    {
        public IEnumerable<AllSalesVM> GetAllSales()
        {
            var sales = this.Context.Sales;
            var viewModel = Mapper.Instance.Map<IEnumerable<Sale>, IEnumerable<AllSalesVM>>(sales);

            return viewModel;
        }

        public AllSalesVM GetSalesById(int id)
        {
            var sales = this.Context.Sales.Find(id);
            var viewModel = Mapper.Instance.Map<Sale, AllSalesVM>(sales);

            return viewModel;
        }

        public IEnumerable<AllSalesVM> GetDiscountedSales(double? percent)
        {
            IEnumerable<Sale> sales = this.Context.Sales.Where(sale => sale.Discount != 0);

            if (percent != null)
            {
                percent /= 100;
                sales = sales.Where(sale => sale.Discount == percent.Value);
            }

            IEnumerable<AllSalesVM> viewModel = Mapper.Map<IEnumerable<Sale>, IEnumerable<AllSalesVM>>(sales);
            return viewModel;
        }

        public SalesAddVM GetSalesVM()
        {
            var viewModels = new SalesAddVM();
            IEnumerable<Customer> customers = this.Context.Customers;
            IEnumerable<Car> cars = this.Context.Cars;

            var carsVM = Mapper.Map<IEnumerable<Car>, IEnumerable<SalesAddCarsVM>>(cars);
            var customersVM = Mapper.Map<IEnumerable<Customer>, IEnumerable<SalesAddCustomersVM>>(customers);

            List<int> discounts = new List<int>();
            for (int i = 0; i <= 50; i += 5)
            {
                discounts.Add(i);
            }

            viewModels.CarsId = carsVM;
            viewModels.CustomersId = customersVM;
            viewModels.Discounts = discounts;

            return viewModels;
        }

        public SaleAddConfirmationVM GetAddConfirmationVM(SaleAddBM bind)
        {
            Car car = this.Context.Cars.Find(bind.CarsId);
            Customer customer = this.Context.Customers.Find(bind.CustomersId);
            SaleAddConfirmationVM viewModel = new SaleAddConfirmationVM()
            {
                Discount = bind.Discount,
                CarId = car.Id,
                CarName = $"{car.Make} {car.Model}",
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                CarPrice = (decimal)car.Parts.Sum(part => part.Price).Value
            };

            viewModel.Discount += customer.IsYoungDriver ? 5 : 0;
            viewModel.CarFinalPrice = viewModel.CarPrice - viewModel.CarPrice * viewModel.Discount / 100;

            return viewModel;
        }

        public void AddSale(SaleAddBM bind, int userId)
        {
            Car car = this.Context.Cars.Find(bind.CarsId);
            Customer customer = this.Context.Customers.Find(bind.CustomersId);
            Sale sale = new Sale()
            {
                Car = car,
                Customer = customer,
                Discount = bind.Discount / 100.00
            };
            this.Context.Sales.Add(sale);
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Add, "sales");
        }
    }
}
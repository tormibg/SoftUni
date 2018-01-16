using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.BindingModels;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;

namespace CarDealer.Services
{
    public class CustomersService : Service
    {
        public IEnumerable<AllCustomerVM> GetAllOrderedCustomers(string order)
        {
            IEnumerable<Customer> customers;
            if (order == "ascending")
            {
                customers =
                    this.Context.Customers.OrderBy(customer => customer.BirthDate)
                        .ThenBy(customer => customer.IsYoungDriver);
            }
            else if (order == "descending")
            {
                customers =
                    this.Context.Customers.OrderByDescending(customer => customer.BirthDate)
                        .ThenBy(customer => customer.IsYoungDriver);
            }
            else
            {
                throw new ArgumentException("The argument must be ascending or descending");
            }

            IEnumerable<AllCustomerVM> viewModels =
                Mapper.Instance.Map<IEnumerable<Customer>, IEnumerable<AllCustomerVM>>(customers);

            return viewModels;
        }

        public AboutCustomerVM GetCustomerById(int id)
        {
            var customer = this.Context.Customers.Find(id);
            var boughtCarsCount = customer.Sales.Count;
            var totalSpentMoney = customer.Sales.Sum(c => c.Car.Parts.Sum(p => p.Price));

            var viewModel = new AboutCustomerVM()
            {
                BoughtCarsCount = boughtCarsCount,
                TotalSpentMoney = totalSpentMoney,
                Name = customer.Name
            };

            return viewModel;
        }

        public void AddCustomer(AddCustomerBM bind)
        {
            Customer customer = Mapper.Map<AddCustomerBM, Customer>(bind);
            if (DateTime.Now.Year - bind.BirthDate.Year < 21)
            {
                customer.IsYoungDriver = true;
            }
            this.Context.Customers.Add(customer);
            this.Context.SaveChanges();
        }

        public EditCustomerVM GetCustomerEditVM(int id)
        {
            var customer = this.Context.Customers.Find(id);
            var viewModel = Mapper.Map<Customer, EditCustomerVM>(customer);

            return viewModel;
        }

        public void EditCustomer(EditCustomerBM bind)
        {
            var customer = this.Context.Customers.Find(bind.Id);
            if (customer != null)
            {
                customer.Name = bind.Name;
                customer.BirthDate = bind.BirthDate;
                if (DateTime.Now.Year - bind.BirthDate.Year < 21)
                {
                    customer.IsYoungDriver = true;
                }
                this.Context.SaveChanges();
            }
        }
    }
}

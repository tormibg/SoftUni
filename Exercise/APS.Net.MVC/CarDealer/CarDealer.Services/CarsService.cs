using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarDealer.Models.BindingModels;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels;
using CarDealer.Models.ViewModels.Car;
using CarDealer.Models.ViewModels.Part;

namespace CarDealer.Services
{
    public class CarsService : Service
    {
        public IEnumerable<CarsByMakeVM> GetCarsByMake(string make)
        {
            if (make == null)
            {
                make = String.Empty;
            }

            var cars =
                this.Context.Cars.Where(c => c.Make.Contains(make))
                    .OrderBy(c => c.Model)
                    .ThenBy(c => c.TravelledDistance);

            var viewModels = Mapper.Instance.Map<IEnumerable<Car>, IEnumerable<CarsByMakeVM>>(cars);

            return viewModels;
        }

        public AboutCarVM GetCarAndPartsById(int id)
        {
            var car = this.Context.Cars.Find(id);
            var parts = car.Parts;

            var carVM = Mapper.Instance.Map<Car, CarsByMakeVM>(car);
            var partsVM = Mapper.Instance.Map<IEnumerable<Part>, IEnumerable<PartsVM>>(parts);

            var viewModel = new AboutCarVM()
            {
                Car = carVM,
                Parts = partsVM
            };

            return viewModel;
        }

        public void AddCar(AddCarBM bind, int userId)
        {
            var car = Mapper.Map<AddCarBM, Car>(bind);

            int[] partIds = bind.Parts.Split(' ').Select(int.Parse).ToArray();
            foreach (var partId in partIds)
            {
                Part part = this.Context.Parts.Find(partId);
                if (part != null)
                {
                    car.Parts.Add(part);
                }
            }

            this.Context.Cars.Add(car);
            this.Context.SaveChanges();

            this.AddLog(userId, OperationLog.Add, "cars");
        }

        public CarAddVm GetCarAddModel()
        {
            var cars = new CarAddVm();
            var parts = new List<PartForCarModel>();
            var allParts = this.Context.Parts;

            foreach (var part in allParts)
            {
                parts.Add(new PartForCarModel()
                {
                    Id = part.Id,
                    Name = part.Name
                });
            }

            cars.Parts = parts;
            return cars;
        }

        public Car GetCarViewMoldes(int id)
        {
            var car = this.Context.Cars.Find(id);
            if (car == null)
            {
                throw new ArgumentOutOfRangeException(nameof(id), id, "There is no such element with provided ID");
            }
            else if (car.TravelledDistance > 1000000)
            {
                throw new InvalidOperationException("The car is to old to be driven!");
            }

            return car;
        }
    }
}
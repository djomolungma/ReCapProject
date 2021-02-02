using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            carManager.Add(new Car
            { Id = 6, BrandId = 3, ColorId = 3, DailyPrice = 250000, ModelYear = 2021, Description = "BMW X5" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.ModelYear} - {car.Description}");
            }

            Car singlecar = carManager.GetById(1);
            Console.WriteLine($"{singlecar.ModelYear} - {singlecar.Description}");

            Console.WriteLine($"----Get By All Brand Id------------------------");
            foreach (var car in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine($"{car.ModelYear} - {car.Description}");
            }
            Console.WriteLine($"----Get By All Brand Id------------------------");
        }
    }
}

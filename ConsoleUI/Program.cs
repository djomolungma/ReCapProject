using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car
            //{ BrandId = 3, ColorId = 1, DailyPrice = 250000, ModelYear = 2021, Description = "BMW X5" });
            //carManager.Add(new Car
            //{ BrandId = 3, ColorId = 2, DailyPrice = 150000, ModelYear = 2021, Description = "BMW X3" });
            //carManager.Add(new Car
            //{ BrandId = 3, ColorId = 3, DailyPrice = 350000, ModelYear = 2021, Description = "BMW X6" });

            //carManager.Add(new Car
            //{ BrandId = 1, ColorId = 3, DailyPrice = 0, ModelYear = 2021, Description = "Fiat palio" });

            //carManager.Add(new Car
            //{ BrandId = 1, ColorId = 3, DailyPrice = 0, ModelYear = 2021, Description = "" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.ModelYear} - {car.Description}");
            }

            Car singlecar = carManager.GetById(1);
            Console.WriteLine($"{singlecar.ModelYear} - {singlecar.Description}");

            Console.WriteLine($"----Get Cars By Brand Id------------------------");
            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine($"{car.ModelYear} - {car.Description}");
            }
            Console.WriteLine($"----Get Cars By Brand Id------------------------");

            Console.WriteLine($"----Get Cars By Color Id------------------------");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine($"{car.ModelYear} - {car.Description}");
            }
            Console.WriteLine($"----Get Cars By Color Id------------------------");

            Console.WriteLine($"----Daili Price Bigger Then 0------------------------");
            foreach (var car in carManager.GetByDailyPrice(1))
            {
                Console.WriteLine($"{car.ModelYear} - {car.Description}");
            }
            Console.WriteLine($"----Daili Price Bigger Then 0------------------------");

        }
    }
}

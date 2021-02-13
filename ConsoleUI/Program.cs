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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

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

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.ModelYear} - {car.Description}");
            }

            Car singlecar = carManager.GetById(1).Data;
            Console.WriteLine($"{singlecar.ModelYear} - {singlecar.Description}");

            Console.WriteLine($"----Get Cars By Brand Id------------------------");
            foreach (var car in carManager.GetCarsByBrandId(3).Data)
            {
                Console.WriteLine($"{car.ModelYear} - {car.Description}");
            }
            Console.WriteLine($"----Get Cars By Brand Id------------------------");

            Console.WriteLine($"----Get Cars By Color Id------------------------");
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine($"{car.ModelYear} - {car.Description}");
            }
            Console.WriteLine($"----Get Cars By Color Id------------------------");

            Console.WriteLine($"----Daili Price Bigger Then 0------------------------");
            foreach (var car in carManager.GetByDailyPrice(1).Data)
            {
                Console.WriteLine($"{car.ModelYear} - {car.Description}");
            }
            Console.WriteLine($"----Daili Price Bigger Then 0------------------------");

            Console.WriteLine($"----CRUD operations------------------------");
            Console.WriteLine($"----Car operations------------------------");
            carManager.Add(new Car
            { BrandId = 3, ColorId = 1, DailyPrice = 112000, ModelYear = 2010, Description = "BMW X1" });

            Console.WriteLine($"----End Car operations------------------------");
            Console.WriteLine($"----Brand operations------------------------");
            brandManager.Add(new Brand { Code = "Fiat",Name = "Fiat" });
            brandManager.Add(new Brand { Code = "Toyota", Name = "Toyota" });
            brandManager.Add(new Brand { Code = "BMW", Name = "BMW" });
            Console.WriteLine($"----End Brand operations------------------------");
            Console.WriteLine($"----Color operations------------------------");
            colorManager.Add(new Color() { Code = "Red", Name = "Red" });
            colorManager.Add(new Color() { Code = "White", Name = "White" });
            colorManager.Add(new Color() { Code = "Black", Name = "Black" });
            Console.WriteLine($"----End Color operations------------------------");
            Console.WriteLine($"----END CRUD operations------------------------");

            Console.WriteLine($"----Car details------------------------");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{car.CarId} | {car.CarName} | {car.BrandName} | {car.ColorName} | {car.DailyPrice}");
            }
            Console.WriteLine($"----End Car details------------------------");
        }
    }
}

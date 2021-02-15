using Business.Concrete;
using Core.Utilities.Results;
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
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

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

            //Console.WriteLine($"----CRUD operations------------------------");
            //Console.WriteLine($"----Car operations------------------------");
            //carManager.Add(new Car
            //{ BrandId = 3, ColorId = 1, DailyPrice = 112000, ModelYear = 2010, Description = "BMW X1" });

            //Console.WriteLine($"----End Car operations------------------------");
            
            //Console.WriteLine($"----Brand operations------------------------");
            //brandManager.Add(new Brand { Code = "Fiat",Name = "Fiat" });
            //brandManager.Add(new Brand { Code = "Toyota", Name = "Toyota" });
            //brandManager.Add(new Brand { Code = "BMW", Name = "BMW" });
            //Console.WriteLine($"----End Brand operations------------------------");
            //Console.WriteLine($"----Color operations------------------------");
            //colorManager.Add(new Color() { Code = "Red", Name = "Red" });
            //colorManager.Add(new Color() { Code = "White", Name = "White" });
            //colorManager.Add(new Color() { Code = "Black", Name = "Black" });
            //Console.WriteLine($"----End Color operations------------------------");
            //Console.WriteLine($"----END CRUD operations------------------------");

            Console.WriteLine($"----Car details------------------------");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{car.CarId} | {car.CarName} | {car.BrandName} | {car.ColorName} | {car.DailyPrice}");
            }
            Console.WriteLine($"----End Car details------------------------");

            Console.WriteLine($"----Customer operations------------------------");
            //customerManager.Add(new Customer
            //{ Code = "001", CompanyName = "Probar", UserId =1});

            //customerManager.Add(new Customer
            //{ Code = "002", CompanyName = "Arena", UserId = 1 });
            Console.WriteLine($"----End Customer operations------------------------");

            Console.WriteLine($"----List Customers ------------------------");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{ customer.Code} - { customer.CompanyName}");
            }
            Console.WriteLine($"----end list customers ------------------------");

            Console.WriteLine($"----Rental operations------------------------");
            //Result result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021,2,13), ReturnDate = new DateTime(2020, 2, 20) });
            //Result result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = new DateTime(2021, 2, 13), ReturnDate = new DateTime(2021, 2, 23) });
            IResult result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 2, 13), ReturnDate = new DateTime(1900, 1, 1) });            
            Console.WriteLine(result.Message);

            Console.WriteLine($"----end Rental operations------------------------");

            Console.WriteLine($"----List rental ------------------------");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine($"{ rental.CarId} - { rental.CustomerId} - { rental.RentDate} - { rental.ReturnDate}");
            }
            Console.WriteLine($"----end list rental ------------------------");
        }
    }
}

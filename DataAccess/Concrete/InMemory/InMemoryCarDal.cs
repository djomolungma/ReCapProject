using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2014, DailyPrice = 100000, Description ="Toyota Yaris" },
                new Car { Id = 2, BrandId = 1, ColorId = 1, ModelYear = 2015, DailyPrice = 120000, Description ="Toyota Corolla" },
                new Car { Id = 3, BrandId = 2, ColorId = 2, ModelYear = 2018, DailyPrice = 150000, Description ="Wolksvagen Golf" },
                new Car { Id = 4, BrandId = 2, ColorId = 3, ModelYear = 2019, DailyPrice = 180000, Description ="Wolksvagen Passat" },
                new Car { Id = 5, BrandId = 3, ColorId = 3, ModelYear = 2020, DailyPrice = 200000, Description ="BMW X3" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);
            _cars.Remove(carToDelete); 
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        //public Car GetById(int carId)
        //{
        //    return _cars.SingleOrDefault(c => c.Id == carId);
        //}

        //public List<Car> GetAllByBrandId(int brandId)
        //{
        //    return _cars.Where(c=>c.BrandId == brandId).ToList();
        //}

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.Where(c => c.Id == car.Id).FirstOrDefault() ;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}

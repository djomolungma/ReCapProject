using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : ICarDal
    {
        public void Add(Car car)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return new List<Car>() { new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 50000, Description = "BMW X5" } };
        }

        public List<Car> GetAllByBrandId(int BrandId)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}

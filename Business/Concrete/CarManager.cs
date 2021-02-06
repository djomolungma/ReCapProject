using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal; 
        }

        public void Add(Car car)
        {
            if (car.Description.Length < 2 )
                throw new Exception("Açıklama minimum 2 karakter olabilir!");
            else if (car.DailyPrice <= 0)
                throw new Exception("Dünlük fiyat 0 dan büyük olmalı");
            else
                _carDal.Add(car);
        }

        

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();   
        }

        public List<Car> GetByDailyPrice(double min, double max = -1)
        {                        
            return max > -1
                ? _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max)
                : _carDal.GetAll(c => c.DailyPrice >= min);
        }        

        //public List<Car> GetAllByBrandId(int brandId)
        //{
        //    return _carDal.GetAll(c=>c.BrandId == brandId);
        //}

        public Car GetById(int carId)
        {
            return _carDal.Get(c=>c.Id == carId); 
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}

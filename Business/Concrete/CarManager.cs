using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DTOs.Entities;
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
        
        public IResult Add(Car car)
        {
            //business codes
            //validations
            //businness kodu ayrı validation kodu ayrı yapılmalı !!!


            //1.kötü kod örneği
            //if (car.DailyPrice <= 0)
            //{
            //    return new ErrorResult(Messages.CarDailyPriceInvalid);
            //}
            //if (car.Description.Length < 2)
            //{
            //    //Antipatern == kötü kullanım

            //    //Magic strings
            //    return new ErrorResult(Messages.CarNameInvalid);
            //}

            //2.biraz daha iyi kod örneği spagetti
            //var context = new ValidationContext<Car>(car);
            //CarValidator carValidator = new CarValidator();
            //var result = carValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            //3.Refactor edilmiş daha iyi kod örneği
            ValidationTool.Validate(new CarValidator(), car);
            
            _carDal.Add(car);

            return new SuccessResult(Messager.CarAdded);
        }

        

        public IResult Delete(Car car)
        {
            var carToDelete = _carDal.Get(c => c.Id == car.Id);
            _carDal.Delete(carToDelete);
            return new SuccessResult(Messager.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messager.CarsListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(double min, double max = -1)
        {                        
            //return max > -1
            //    ? _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max)
            //    : _carDal.GetAll(c => c.DailyPrice >= min);

            return new SuccessDataResult<List<Car>>(max > -1
                ? _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max)
                : _carDal.GetAll(c => c.DailyPrice >= min), Messager.CarsByDailyPriceListed);
        }        

        //public List<Car> GetAllByBrandId(int brandId)
        //{
        //    return _carDal.GetAll(c=>c.BrandId == brandId);
        //}

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId), Messager.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messager.CarsWithDetailsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messager.CarsByBrandIdListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messager.CarsByColorIdListed);
        }

        public IResult Update(Car car)
        {
            var carToUpdate = _carDal.Get(c => c.Id == car.Id);
            _carDal.Update(carToUpdate);
            return new SuccessDataResult<List<Car>>(Messager.CarUpdated);
        }
    }
}

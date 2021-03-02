using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExeeded(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result; 
            }

            var carImageToDelete = _carImageDal.Get(c => c.Id == carImage.Id);
            _carImageDal.Delete(carImageToDelete);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file,CarImage carImage)
        {
            var carImageToUpdate = _carImageDal.Get(c => c.Id == carImage.Id);

            carImageToUpdate.ImagePath = FileHelper.Update(_carImageDal.Get(c=>c.Id == carImage.Id).ImagePath,file);
            carImageToUpdate.Date = DateTime.Now;
            _carImageDal.Update(carImageToUpdate);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        private IResult CheckIfImageLimitExeeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(c => c.CarId == carId).Count; 
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExeeded);
            }
            return new SuccessResult();
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                FileHelper.Delete(carImage.ImagePath);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message); 
            }
            return new SuccessResult(); 
        }

        private List<CarImage> CheckIfCarImageNull(int carId)
        {            
            string path = Environment.CurrentDirectory + @"\Images\CarImages\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(c => c.CarId == carId);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
    }
}

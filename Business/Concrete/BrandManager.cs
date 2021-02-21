using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messager.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            var brandToDelete = _brandDal.Get(b => b.Id == brand.Id);
            _brandDal.Delete(brandToDelete);
            return new SuccessResult(Messager.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {            
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messager.BrandsListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {            
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId), Messager.BrandsListed);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            var brandToUpdate = _brandDal.Get(b => b.Id == brand.Id);
            _brandDal.Update(brandToUpdate);
            return new SuccessResult(Messager.BrandUpdated);
        }
    }
}

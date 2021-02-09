using Business.Abstract;
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

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            var brandToDelete = _brandDal.Get(b => b.Id == brand.Id);
            _brandDal.Delete(brandToDelete);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.Get(b=>b.Id==brandId);
        }

        public void Update(Brand brand)
        {
            var brandToUpdate = _brandDal.Get(b => b.Id == brand.Id);
            _brandDal.Update(brandToUpdate);
        }
    }
}

using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messager.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            var colorToDelete = _colorDal.Get(c=>c.Id == color.Id);
            _colorDal.Delete(colorToDelete);
            return new SuccessResult(Messager.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {            
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messager.BrandsListed);

        }

        public IDataResult<Color> GetById(int colorId)
        {            
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId), Messager.ColorsListed);
        }

        public IResult Update(Color color)
        {
            var colorToUpdate = _colorDal.Get(c => c.Id == color.Id);
            _colorDal.Update(colorToUpdate);
            return new SuccessResult(Messager.ColorUpdated);
        }
    }
}

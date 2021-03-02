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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            var colorToDelete = _colorDal.Get(c=>c.Id == color.Id);
            _colorDal.Delete(colorToDelete);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {            
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.BrandsListed);

        }

        public IDataResult<Color> GetById(int colorId)
        {            
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId), Messages.ColorsListed);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            var colorToUpdate = _colorDal.Get(c => c.Id == color.Id);
            _colorDal.Update(colorToUpdate);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}

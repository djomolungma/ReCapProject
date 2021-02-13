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
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IResult Add(Model model)
        {            
            _modelDal.Add(model);
            return new SuccessResult(Messager.ModelAdded);
        }

        public IResult Delete(Model model)
        {
            var modelToDelete = _modelDal.Get(m => m.Id == model.Id);
            _modelDal.Delete(modelToDelete);
            return new SuccessResult(Messager.ModelDeleted);
        }

        public IDataResult<List<Model>> GetAll()
        {            
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(), Messager.ModelsListed);
        }

        public IDataResult<Model> GetById(int modelId)
        {            
            return new SuccessDataResult<Model>(_modelDal.Get(m => m.Id == modelId), Messager.ModelsListed);
        }

        public IResult Update(Model model)
        {
            var modelToUpdate = _modelDal.Get(m => m.Id == model.Id);
            _modelDal.Update(modelToUpdate);
            return new SuccessResult(Messager.ModelUpdated);
        }
    }
}

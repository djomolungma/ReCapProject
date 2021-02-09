using Business.Abstract;
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

        public void Add(Model model)
        {
            _modelDal.Add(model);
        }

        public void Delete(Model model)
        {
            var modelToDelete = _modelDal.Get(m => m.Id == model.Id);
            _modelDal.Delete(modelToDelete);
        }

        public List<Model> GetAll()
        {
            return _modelDal.GetAll();
        }

        public Model GetById(int modelId)
        {
            return _modelDal.Get(m=>m.Id == modelId);
        }

        public void Update(Model model)
        {
            var modelToUpdate = _modelDal.Get(m => m.Id == model.Id);
            _modelDal.Update(modelToUpdate);
        }
    }
}

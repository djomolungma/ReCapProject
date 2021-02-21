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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messager.UserAdded);
        }

        public IResult Delete(User user)
        {
            var userToDelete = _userDal.Get(u => u.Id == user.Id);
            _userDal.Delete(userToDelete);
            return new SuccessResult(Messager.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            var userToUpdate = _userDal.Get(c => c.Id == user.Id);
            _userDal.Delete(userToUpdate);
            return new SuccessResult(Messager.UserUpdate);
        }
    }
}

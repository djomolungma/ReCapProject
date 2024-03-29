﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            if (IsCarReturned(rental.CarId))
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }                
            else
            {
                return new ErrorResult(Messages.RentalReturnDateInvalid);
            }                        
        }

        public IResult Delete(Rental rental)
        {
            var rentalToDelete = _rentalDal.Get(r => r.Id == rental.Id);
            _rentalDal.Delete(rentalToDelete);
            return new SuccessResult(Messages.RentalDeleted);
        }

        private bool IsCarReturned(int carId)
        {
            if (_rentalDal.GetAll(r => r.CarId == carId && (r.ReturnDate == null || r.ReturnDate >= DateTime.Now)).Count > 0)
                return false;
            else
                return true;
        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IResult Update(Rental rental)
        {
            var rentalToUpdate = _rentalDal.Get(c => c.Id == rental.Id);
            _rentalDal.Delete(rentalToUpdate);
            return new SuccessResult(Messages.RentalUpdate);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalWithDetailsListed);
        }
    }
}

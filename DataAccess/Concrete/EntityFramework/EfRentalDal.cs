using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var list = (from r in context.Rentals join
                            c in context.Cars on r.CarId equals c.Id join
                            b in context.Brands on c.BrandId equals b.Id join
                            cm in context.Customers on r.CustomerId equals cm.Id
                            select new RentalDetailDto
                            {
                                RentalId = r.Id,
                                BrandName = b.Name,
                                FullName = cm.CompanyName,
                                RentDate = r.RentDate,
                                ReturnDate = r.ReturnDate,                                                               
                            }).ToList();

                return list;
            }
        }
    }
}

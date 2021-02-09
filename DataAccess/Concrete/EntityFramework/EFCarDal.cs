using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DTOs.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityFrameworkBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var list = (from c in context.Cars join
                           b in context.Brands on c.BrandId equals b.Id join
                           cl in context.Colors on c.ColorId equals cl.Id
                           select new CarDetailDto
                           {
                                CarId = c.Id,
                                 CarName = c.Description,
                                  DailyPrice = c.DailyPrice,
                                   BrandName = b.Name,
                                    ColorName = cl.Name 
                           }).ToList(); 

                return list;
            }            
        }
    }
}

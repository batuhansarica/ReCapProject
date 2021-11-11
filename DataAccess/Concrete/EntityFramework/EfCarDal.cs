using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
                             join co in context.Colors
                             on p.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = c.BrandName,
                                 CarName = p.CarName,
                                 ColorName=co.ColorName,
                                 DailyPrice = p.DailyPrice

                             };
                return result.ToList();

            }
        }
    }
}

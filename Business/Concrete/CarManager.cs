using Business.Abstract;
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
    public class CarManager : ICarService
    {
        ICarDal  _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length == 2 && car.DailyPrice > 0)
            {
                return new ErrorResult(Messages.CarInvalid);

            }
            _carDal.Add(car);
            return new SuccesResult(Messages.CarAdded);

        }
        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour==17)
            { 
                return new ErrorDataResult<List<Car>>(_carDal.GetAll(), Messages.MaintenanceTime);
            }
            
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccesDataResult<List<Car>> (_carDal.GetAll(p => p.BrandId == id));
        }

    

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccesDataResult<List<Car>>( _carDal.GetAll(p => p.ColorId == id));
        }

     
    }
}

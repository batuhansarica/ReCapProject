﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=5000, ModelYear=2011, Description="Renault Kangoo"},
            new Car{CarId=2, BrandId=2, ColorId=2, DailyPrice=6000, ModelYear=2012, Description="Fiat Doblo"},
            new Car{CarId=3, BrandId=3, ColorId=3, DailyPrice=7000, ModelYear=2013, Description="Seat Toledo"},
            new Car{CarId=4, BrandId=4, ColorId=4, DailyPrice=8000, ModelYear=2014, Description="Opel Corsa"},
            new Car{CarId=5, BrandId=5, ColorId=5, DailyPrice=9000, ModelYear=2015, Description="Bmw 520d"}
            };
        }
  
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}

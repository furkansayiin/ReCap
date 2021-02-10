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
            _cars = new List<Car>
            {
                new Car{CarId = 1 , BrandId = 1 , ColorId = 1 , DailyPrice = 250 , ModelYear = "2013" , Description = "Honda Accord"},
                new Car{CarId = 2 , BrandId = 2 , ColorId = 2 , DailyPrice = 500 , ModelYear = "2015" , Description = "Volkswagen Passat"},
                new Car{CarId = 3 , BrandId = 3 , ColorId = 3 , DailyPrice = 750 , ModelYear = "2017" , Description = "Ford Focus"},
                new Car{CarId = 4 , BrandId = 4 , ColorId = 4 , DailyPrice = 1000, ModelYear = "2021" , Description = "Mercedes C180"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();

        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}

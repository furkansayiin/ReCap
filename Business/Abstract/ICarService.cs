using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByColorId(int colorId);
        List<Car> GetAllByBrandId(int brandId);
        List<Car> GetByDailyPrice(decimal min , decimal max);
        List<Car> GetByModelYear(string modelYear);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}

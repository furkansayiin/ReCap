using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IEnumerable<object> GetAllBrandId(int v)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public List<Car> Get()
        {
            return _carDal.Get();
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<Car> GetByModelYear(string modelYear)
        {
            return _carDal.GetAll(c => c.ModelYear.Contains(modelYear) == true);
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araç Başarıyla Eklenmiştir.");
            }
            else
            {
                Console.WriteLine("Lütfen günlük fiyat kısmına 0'dan büyük giriniz.Girdiğiniz değer : {car.DailyPrice}");
            }
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araç Başarıyla Güncellendi.");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araç Başarıyla Silindi.");
        }
    }
}

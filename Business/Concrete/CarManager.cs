using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result;
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

        public object GetAllByBrandId()
        {
            throw new NotImplementedException();
        }

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetByModelYear(int modelYear)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == modelYear));
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                return new ErrorResult(Messages.CarNameInvalid);

            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
          
        }

        public IResult Update(Car car)
        {
            if (car.BrandId == car.BrandId)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);   
            }
                return new ErrorResult(Messages.BrandIdInvalid);
        }

        public IResult Delete(Car car)
        {
            if (car.BrandId == car.BrandId)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            return new ErrorResult(Messages.BrandIdInvalid);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }
    }
}

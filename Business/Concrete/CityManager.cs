﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class CityManager:ICityService
    {
        ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public IResult add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult();
        }

        public IResult delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult();
        }

        public IDataResult<City> get()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<City>> getAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll());
        }

        public IResult update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult();
        }
    }
}

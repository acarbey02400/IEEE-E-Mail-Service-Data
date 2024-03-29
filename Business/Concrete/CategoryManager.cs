﻿using Business.Abstract;
using Business.Constants;
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
   public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult add(Category category)
        {
            
            _categoryDal.Add(category);
            return new SuccessResult(Messages.added);
           
        }

        public IResult delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
        }

        public IDataResult<Category> get()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> getAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IResult update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }
       
    }
}

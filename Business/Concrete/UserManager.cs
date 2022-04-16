using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entity;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager :IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult add(User user)
        {
                _userDal.Add(user);
                return new SuccessResult(Messages.added);
        }

        public IResult delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.deleted);
        }

        public IDataResult<List<User>> getAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> getById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.id == id));
        }

        public IDataResult<List<User>> getByTypeId(int UserType)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(p=>p.roleId== UserType));
        }

        public IDataResult <List<UserDetailDto>> getUserDetail()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetail());
        }

        public IResult update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.success);
        }

        public IDataResult<User> validation(string userName, string password,int UserType)
        {
            var result = _userDal.logInControl(userName, password,UserType);
            
            if (result==null)
            {
                return new ErrorDataResult<User>("Yanlış kullanıcı adı veya şifre");
            }
            
            return new SuccessDataResult<User>(result, Messages.success);
        }
    }
}

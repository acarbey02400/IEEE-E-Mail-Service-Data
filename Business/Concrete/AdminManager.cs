using Business.Abstract;
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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        //public IResult add(Admin admin)
        //{
        //   var result = validation(admin);
        //    if (result.Success)
        //    {
        //        _adminDal.Add(admin);
        //        return new SuccessResult(Messages.added);
        //    }
        //    return result;
        //}

        //public IResult delete(Admin admin)
        //{
        //    _adminDal.Delete(admin);
        //    return new SuccessResult(Messages.deleted);
        //}

        public IDataResult<Admin> get()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Admin>> getAll()
        {
            return new SuccessDataResult<List<Admin>>(_adminDal.GetAll(),Messages.listed);
        }

        //public IResult update(Admin admin)
        //{
        //    _adminDal.Update(admin);
        //    return new SuccessResult(Messages.success);
        //}
    
       

        public IDataResult<Admin> getById(int id)
        {
            return new SuccessDataResult<Admin>(_adminDal.Get(p => p.id == id));
        }
    }
}

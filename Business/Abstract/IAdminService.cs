using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IAdminService
    {
        //public IResult add(Admin admin);
        //public IResult update(Admin admin);
        //public IResult delete(Admin admin);
        public IDataResult<List<Admin>> getAll();
        public IDataResult<Admin> get();
        public IDataResult<Admin> getById(int id);
    }
}

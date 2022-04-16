using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IEmployeeService
    {
        //public IResult add(Employee employee);
        //public IResult update(Employee employee);
        //public IResult delete(Employee employee);
        public IDataResult<List<Employee>> getAll();
        public IDataResult<Employee> get();
        public IDataResult<Employee> getById(int id);
    }
}

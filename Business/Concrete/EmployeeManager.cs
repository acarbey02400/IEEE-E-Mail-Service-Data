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
   public class EmployeeManager:IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        //public IResult add(Employee employee)
        //{
        //    var result = validation(employee);
        //    if (result.Success)
        //    {
        //        _employeeDal.Add(employee);
        //        return new SuccessResult(Messages.added);
        //    }
        //    return result;
        //}

        //public IResult delete(Employee employee)
        //{
        //    _employeeDal.Delete(employee);
        //    return new SuccessResult(Messages.deleted);
        //}

        public IDataResult<Employee> get()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Employee>> getAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(), Messages.listed);
        }

        //public IResult update(Employee employee)
        //{
        //    _employeeDal.Update(employee);
        //    return new SuccessResult(Messages.success);
        //}


        public IDataResult<Employee> getById(int id)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(p => p.id == id));
        }
    }
}

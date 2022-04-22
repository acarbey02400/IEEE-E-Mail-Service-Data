using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class CustomerManger:ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManger(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult add(Customer customer)
        {
           
                _customerDal.Add(customer);
                return new SuccessResult(Messages.added);
            
            
           
        }

        public IResult delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.deleted);
        }

        public IDataResult<Customer> get()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> getAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<CustomerDetailDto>> getCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), Messages.listed);
        }

        public IResult update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.success);
        }
        
        public IDataResult<Customer> getById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.id == id));
        }
    }
}
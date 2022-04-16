using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICustomerService
    {
        public IResult add(Customer customer);
        public IResult update(Customer customer);
        public IResult delete(Customer customer);
        public IDataResult<List<Customer>> getAll();
        public IDataResult<Customer> get();
        public IDataResult<List<CustomerDetailDto>> getCustomerDetail();
        public IDataResult<Customer> getById(int id);
    }
}

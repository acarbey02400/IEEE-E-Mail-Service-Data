using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CustomerDal: EfEntityRepositoryBase<Customer, IEEEDataContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (IEEEDataContext context = new IEEEDataContext())
            {
                var result = from p in context.Customers
                             join ca in context.Categories
                              on p.categoryId equals ca.id
                             join ci in context.Cities
                             on p.cityId equals ci.id
                             select new CustomerDetailDto { id=p.id, address=p.address, categoryName=ca.name, cityName=ci.name, companyName=p.companyName, phoneNumber=p.phoneNumber, eMail=p.eMail};
                return result.ToList();
            }
        }
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EmployeeDal:EfEntityRepositoryBase<Employee,IEEEDataContext>,IEmployeeDal
    {
        public List<Employee> logInControl(string userName, string password)
        {
            using (IEEEDataContext context = new IEEEDataContext())
            {
                var result = from p in context.Employees
                             where p.userName == userName
                             where p.password == password
                             select new Employee { id = p.id };
                return result.ToList();

            }

        }
    }
}

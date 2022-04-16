using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User, IEEEDataContext>, IUserDal
    {
        public User logInControl(string userName, string password,int typeId)
        {
            using (IEEEDataContext context = new IEEEDataContext())
            {
                var result = from p in context.Users
                             where p.userName == userName
                             where p.password == password
                             where p.roleId==typeId
                             select new User { id = p.id };
                return result.FirstOrDefault();

            }
        }
        public List<UserDetailDto> GetUserDetail()
        {
            using (IEEEDataContext context = new IEEEDataContext())
            {
                var result = from p in context.Users
                             join ro in context.Roles
                              on p.roleId equals ro.id
                             select new UserDetailDto { id = p.id, userName=p.userName, lastLogin=p.lastLogin.ToString(), eMail=p.eMail, name=p.firstName, surName=p.lastName, roles=ro.roleName };
                return result.ToList();
            }
        }
    }
}

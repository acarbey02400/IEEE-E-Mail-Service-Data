using Core.DataAccess;
using Core.Entity.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IUserDal:IEntityRepository<User>
    {
        public User logInControl(string userName, string password,int typeId);
        public List<UserDetailDto> GetUserDetail();
    }
}

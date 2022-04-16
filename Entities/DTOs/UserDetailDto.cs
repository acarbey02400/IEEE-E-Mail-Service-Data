using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class UserDetailDto:IDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public string userName { get; set; }
        public string eMail { get; set; }
        public string roles { get; set; }
        public string lastLogin { get; set; }

    }
}

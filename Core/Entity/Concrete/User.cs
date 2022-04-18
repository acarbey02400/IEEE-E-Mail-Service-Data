﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Concrete
{
    public class User:IEntity
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string eMail { get; set; }
        public string password { get; set; }
        public string userName { get; set; }
        public int roleId { get; set; }
        public DateTime lastLogin { get; set; }
    }
}

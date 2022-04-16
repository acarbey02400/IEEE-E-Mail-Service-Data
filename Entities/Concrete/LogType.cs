using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class LogType:IEntity
    {
        public int id { get; set; }
        public int name { get; set; }
    }
}

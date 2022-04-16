using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Log:IEntity
   {
        public int id { get; set; }
        public int userId { get; set; }
        public int customerId { get; set; }
        public int typeId { get; set; }
        public string description { get; set; }
        public DateTime logTime { get; set; }

    }
}

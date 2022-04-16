using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class EMailTemplate
    {
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public string file { get; set; }
    }
}

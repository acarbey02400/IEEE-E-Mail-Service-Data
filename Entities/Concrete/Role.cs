using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    
    public class Role:IEntity
    {
        public int id { get; set; }
        public string roleName { get; set; }
        public int claimId { get; set; }
    }
}

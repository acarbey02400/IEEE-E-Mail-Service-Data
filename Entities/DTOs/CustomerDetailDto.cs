using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class CustomerDetailDto:IDto
    {
        public int id { get; set; }
        public string companyName { get; set; }
        public string cityName { get; set; }
        public string categoryName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string eMail { get; set; }
    }
}

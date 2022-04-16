using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICityService
    {
        public IResult add(City city);
        public IResult update(City city);
        public IResult delete(City city);
        public IDataResult<List<City>> getAll();
        public IDataResult<City> get();
    }
}

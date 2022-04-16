using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ILogService
    {
        public IResult add(Log log);
        public IResult update(Log log);
        public IResult delete(Log log);
        public IDataResult<List<Log>> getAll();
        public IDataResult<Log> getById(int id);
        public IDataResult<List<Log>> getByUserId(int id);
        public IDataResult<List<Log>> getByCustomerId(int id);
       
    }
}

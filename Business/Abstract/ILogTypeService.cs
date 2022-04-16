using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ILogTypeService
    {
        public IResult add(LogType type);
        public IResult update(LogType type);
        public IResult delete(LogType type);
        public IDataResult<List<LogType>> getAll();
        public IDataResult<LogType> getById(int id);
    }
}

using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LogTypeManager : ILogTypeService
    {
        LogTypeDal _logTypeDal;
        public LogTypeManager(LogTypeDal logTypeDal)
        {
            _logTypeDal = logTypeDal;
        }
        public IResult add(LogType type)
        {
            _logTypeDal.Add(type);
            return new SuccessResult(Messages.added);
        }

        public IResult delete(LogType type)
        {
            _logTypeDal.Delete(type);
            return new SuccessResult(Messages.deleted);
        }

        public IDataResult<List<LogType>> getAll()
        {

            return new SuccessDataResult<List<LogType>>(_logTypeDal.GetAll());
        }

        public IDataResult<LogType> getById(int id)
        {
            return new SuccessDataResult<LogType>(_logTypeDal.Get(p=>p.id==id));
        }

        public IResult update(LogType type)
        {
            _logTypeDal.Update(type);
            return new SuccessResult(Messages.success);
        }
    }
}

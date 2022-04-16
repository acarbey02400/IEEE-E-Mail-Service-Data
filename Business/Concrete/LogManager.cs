using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LogManager : ILogService
    {
        ILogDal _logDal;
        public LogManager(ILogDal logDal)
        {
            _logDal = logDal;
        }
        public IResult add(Log log)
        {
            _logDal.Add(log);
            return new SuccessResult(Messages.added);

        }

        public IResult delete(Log log)
        {
            _logDal.Delete(log);
            return new SuccessResult(Messages.deleted);
        }

        public IDataResult<List<Log>> getAll()
        {
            return new SuccessDataResult<List<Log>>(_logDal.GetAll());
        }

        public IDataResult<List<Log>> getByCustomerId(int id)
        {
            return new SuccessDataResult<List<Log>>(_logDal.GetAll(p => p.customerId == id));
        }

        public IDataResult<Log> getById(int id)
        {
            return new SuccessDataResult<Log>(_logDal.Get(p => p.id == id));

        }

        public IDataResult<List<Log>> getByUserId(int id)
        {
            return new SuccessDataResult<List<Log>>(_logDal.GetAll(p => p.userId == id));
        }

        public IResult update(Log log)
        {
            _logDal.Update(log);
            return new SuccessResult(Messages.success);
        }
    }
}

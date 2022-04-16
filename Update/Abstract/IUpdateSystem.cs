using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update.Abstract
{
   public interface IUpdateSystem
    {
        IResult updateControl(string update);
        IResult update(string path, string fileName, string processId);
    }
}

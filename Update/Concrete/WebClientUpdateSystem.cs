using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Update.Abstract;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using AutoUpdaterDotNET;

namespace Update.Concrete
{
    public class WebClientUpdateSystem : IUpdateSystem
    {
        public IResult updateControl(string update)
        {
            using (WebClient wc = new WebClient())
            {
                if (!wc.DownloadString("http://acaribrahim.tr.ht/control.txt").Contains(update))
                {
                    return new SuccessResult();
                }
            }
            return new ErrorResult();
            
        }

        public IResult update(string path, string fileName, string processId)
        {
            TextWriter text = new StreamWriter(@".\updateInfo.txt");
            text.WriteLine(path);
            text.WriteLine(fileName);
            text.WriteLine(processId);
            text.Flush();
            text.Close();
            return new SuccessResult();
        }
    }
}

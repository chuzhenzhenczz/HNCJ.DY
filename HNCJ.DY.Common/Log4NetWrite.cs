using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNCJ.DY.Common
{
    class Log4NetWrite:ILogWrite
    {
        public void WriteLogInfo(string text)
        {
            ILog logWrite = log4net.LogManager.GetLogger("Demo");
            logWrite.Error(text);
        }
    }
}

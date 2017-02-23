using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HNCJ.DY.Common
{
    public class LogHelper
    {
        public static Queue<string> ExceptionStringQueue = new Queue<string>();
        public static List<ILogWrite> LogWriteList = new List<ILogWrite>();
        
        static LogHelper(){
            //LogWriteList.Add(new TextFileWrite());
            LogWriteList.Add(new Log4NetWrite());

            ThreadPool.QueueUserWorkItem(o => {
                while (true)
                {
                    lock (ExceptionStringQueue)
                    {
                        if (ExceptionStringQueue.Count > 0)
                        {
                            string str = ExceptionStringQueue.Dequeue();

                            foreach (var logWrite in LogWriteList)
                            {
                                logWrite.WriteLogInfo(str);
                            }
                        }
                        else
                        {
                            Thread.Sleep(30);
                        }

                    }
                }
            });
        }
        public static void WriteLog(string exceptionText)
        {
            lock (ExceptionStringQueue) {
                ExceptionStringQueue.Enqueue(exceptionText);
            }
        }
    }
}

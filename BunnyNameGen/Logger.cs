using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyNameGen
{
    class Logger
    {
        private StreamWriter logFile;

        public Logger()
        {
            logFile = new StreamWriter("logFile.txt");
        }

        public void LogError(string errorIn)
        {
            logFile.WriteLine("ERROR: {0} {1}, " + errorIn, DateTime.Now.ToShortTimeString(), DateTime.Now.ToShortDateString());
            logFile.Flush();
        }

        public void LogInfo(string infoIn)
        {
            logFile.WriteLine("ERROR: {0} {1}, " + infoIn, DateTime.Now.ToShortTimeString(), DateTime.Now.ToShortDateString());
            logFile.Flush();
        }
    }
}

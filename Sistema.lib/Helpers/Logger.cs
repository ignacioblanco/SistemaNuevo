using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema.lib.Helpers
{
    public static class Logger
    {
        public static void Write(string Message)
        {
            string RutaLogs = ConfigurationManager.AppSettings["RutaLogs"];
            RutaLogs = RutaLogs.Insert(RutaLogs.IndexOf(".log"), "-" + DateTime.Now.ToString("yyyy-MM-dd"));

            using (StreamWriter sw = new StreamWriter(RutaLogs, true, Encoding.Default))
            {
                sw.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + Message);
                sw.Flush();
                sw.Close();
            }
        }
    }
}

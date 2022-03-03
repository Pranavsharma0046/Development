using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
namespace ManageAmericaAPI.Helpers
{
    public static class Logger
    {

        public static void WriteLog(string type, string strLog, string customMsg = "")
        {
            try
            {

                var appPath =  Directory.GetCurrentDirectory();
                string logFilePath = appPath + "/Logs/Log-" + DateTime.Today.ToString("MM-dd-yyyy") + "." + "log";// Setting directory for logfile with current DateTime
                FileInfo logFileInfo = new FileInfo(logFilePath);
                DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();// Check and create directory if not exists
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
                {
                    using (StreamWriter log = new StreamWriter(fileStream))
                    {
                        log.WriteLine(type + ": " + System.DateTime.Now.ToString() + ": " + strLog + " " + customMsg);// Adding to the log file
                    }
                }
            }
            catch (Exception)
            { }
        }
    }
}

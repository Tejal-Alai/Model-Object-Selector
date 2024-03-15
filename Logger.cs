using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ModelSelector
//{
//    class Logger
//    {
//    }
//}
using System.IO;
namespace ModelSelector
{
    /// <summary>
    /// Provides functionality related to logger.
    /// </summary>
    internal class Logger
    {
        /// <summary>
        /// Workspace Directory
        /// </summary>
        private readonly string workspaceDir;
        /// <summary>
        /// Tekla-Connector Folder path in Workspace Directory
        /// </summary>
        private static readonly string appWorkspaceDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Tekla-Connector";

        ///// <summary>
        ///// Instance of Logger class.
        ///// </summary>
        private static Logger logger;
        /// <summary>
        /// Instance of Autodesk.DataExchange.Extensions.Logging.File.Log
        /// </summary>

        /// <summary>
        /// Construcutor of user defined Logger class to initialise non static characteristics of a class and external resources.
        /// </summary>
        public Logger(string appWorkspaceDirectory)
        {
            workspaceDir = appWorkspaceDirectory;
            CreateDirectory();
        }

        /// <summary>
        /// Creates instance if not created of logger class.
        /// </summary>
        /// <returns>returns class instance</returns>
        public static Logger GetInstance()
        {
            if (logger == null)
            {
                logger = new Logger(appWorkspaceDirectory);
            }
            return logger;
        }

        /// <summary>
        /// create directory for logs if not exists at roaming path
        /// </summary>
        public void CreateDirectory()
        {
            string logFileFolderPath = workspaceDir;
            if (!Directory.Exists(logFileFolderPath))
            {
                Directory.CreateDirectory(logFileFolderPath);
            }
        }

        /// <summary>
        /// Used to display execution time.
        /// </summary>
        /// <param name="elapsedtime">Time interval.</param>
        /// <returns>Returns execution time.</returns>
        public string ExecutionTime(TimeSpan elapsedtime)
        {
            TimeSpan timespan = elapsedtime;

            // Format and display the TimeSpan value.
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timespan.Hours, timespan.Minutes, timespan.Seconds,
                timespan.Milliseconds / 10);

            return "Execution Time :" + elapsedTime;
        }

        /// <summary>
        /// Write log file.
        /// </summary>
        /// <param name="logType">Type of log.</param>
        /// <param name="callerFunctionName">Name of function.</param>
        /// <param name="message">Log message.</param>
        /// <param name="exception">Log Exception.</param>
        public void WriteLogFile(string logType, string callerFunctionName, string message, Exception exception)
        {
            switch (logType)
            {
                case "Information":
                    {
                        //log.Information(message, callerFunctionName);

                    }
                    break;
                case "Debug":
                    {

                        //log.Debug(message, callerFunctionName);
                    }
                    break;
                case "Exception":
                    {
                        //log.Error(exception);
                    }
                    break;
                case "Error":
                    {

                        //log.Error(message, callerFunctionName);
                    }
                    break;
                case "Warning":
                    {

                        //log.Warning(message, callerFunctionName);
                    }
                    break;
            }
        }
    }
}

using System;
using System.Data.SqlClient;
using System.IO;

namespace Logger
{
    public class FileLogger
    {
        private static FileLogger _instance = null;

        private static String _fileName = "log.txt";

        public static string FileName
        {
            get => _fileName;
        }

        public static void plant(String fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                _fileName = fileName;
            }
            _instance = new FileLogger();
        }

        public static FileLogger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FileLogger();
                return _instance;
            }
        }

        public void log(string user,string role, String activity)
        {
            string activityLine = DateTime.Now + ";"
                                               + user + ";"
                                               + role + ";"
                                               + activity;
            if (File.Exists(FileName))
                File.AppendAllText(FileName, activityLine + "\n");
        }
    }
}
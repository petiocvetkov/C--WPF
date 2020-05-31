using System;
using UserLogin;

namespace Logger
{
    public class FileLogger
    {
        private static FileLogger _instance = null;

        private static String fileName = "";

        public static FileLogger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FileLogger();
                return _instance;
            }
        }

        public void log(String activity)
        {
            
        }
    }
}
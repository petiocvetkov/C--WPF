using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class Logger
    {
        private static Logger _instance = null;
        
        private static List<string> currentSessionActivities = new List<string>();

        public static void plant()
        {
            _instance = new Logger();
        }
        
        public static void plant(string fileName, string connection)
        {
            _instance = new Logger(fileName, connection);
        }

        private Logger() : this(null, null)
        {
        }

        private Logger(string fileName, string connection)
        {
            DbLogger.plant(connection);
            FileLogger.plant(fileName);
        }
        
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Logger();
                return _instance;
            }
        }

        public void LogActivity(string user, string role, string activity)
        {
            FileLogger.Instance.log(user, role, activity );
            DbLogger.Instance.log(user, role, activity );
        }
        
        public string GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var activities in currentSessionActivities)
                sb.Append(activities);
            return sb.ToString();
        }
    }
}
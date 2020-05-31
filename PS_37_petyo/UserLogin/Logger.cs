using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();

        public static string FileName = "log.txt";

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                                               + LoginValidation.currentUserUsername + ";"
                                               + LoginValidation.currentUserRole + ";"
                                               + activity;
            currentSessionActivities.Add(activityLine);
            
            LogContext.Instance.Logs
                .Add(new Log(DateTime.Now, LoginValidation.currentUserUsername,
                    LoginValidation.currentUserRole.ToString(), activity));
            LogContext.Instance.SaveChanges();

            if (File.Exists(Logger.FileName))
                File.AppendAllText(Logger.FileName, activityLine + "\n");
        }

        public static string GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var activities in currentSessionActivities)
                sb.Append(activities);
            return sb.ToString();
        }
    }
}
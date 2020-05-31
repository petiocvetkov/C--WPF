using System;

namespace Logger
{
    public class Log
    {
        public System.Int32 LogId { get; set; }
        public System.DateTime Date { get; set; }
        public System.String Role { get; set; }
        public System.String User { get; set; }
        public System.String Activity { get; set; }

        public Log()
        {
        }

        public Log(DateTime date, string role, string user, string activity)
        {
            Date = date;
            Role = role;
            User = user;
            Activity = activity;
        }
    }
}
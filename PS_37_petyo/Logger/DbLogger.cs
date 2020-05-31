using System;
using System.Data.Entity;

namespace Logger
{
    public class DbLogger : DbContext
    {
        private static string connection =
            "Data Source=(local);Initial Catalog=StudentInfoDatabase;Integrated Security=True";
        
        private static DbLogger _instance = null;

        public static void plant(string connectionString)
        {
            if (!String.IsNullOrEmpty(connectionString))
            {
                connection = connectionString;
            }
            _instance = new DbLogger(connection);
        }
        
        public static DbLogger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DbLogger(connection);
                return _instance;
            }
        }
        
        public DbSet<Log> Logs { get; set; }


        protected DbLogger(string connection) : base(connection)
        {
        }

        public void log(string user, string role,string activity)
        {
            Logs
                .Add(new Log(DateTime.Now, user,
                    role, activity));
            SaveChanges();
        }
    }
}
using System.Data.Entity;

namespace UserLogin
{
    public class LogContext : DbContext
    {
        private static LogContext _instance = null;

        public static LogContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LogContext();
                return _instance;
            }
        }
        
        public DbSet<Log> Logs { get; set; }


        protected LogContext() : base("Data Source=(local);Initial Catalog=StudentInfoDatabase;Integrated Security=True")
        {
        }
    }
}
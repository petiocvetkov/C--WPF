using System.Data.Entity;
using UserLogin;

namespace Logger
{
    public class DbLogger : DbContext
    {
        
        private static DbLogger _instance = null;

        public static DbLogger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DbLogger();
                return _instance;
            }
        }
        
        public DbSet<Log> Logs { get; set; }


        protected DbLogger() : base("Data Source=(local);Initial Catalog=StudentInfoDatabase;Integrated Security=True")
        {
        }
    }
}
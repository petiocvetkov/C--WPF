using System.Data.Entity;

namespace UserLogin
{
    public class UserContext: DbContext
    {
        
        private static UserContext _instance = null;

        
        public static UserContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserContext();
                return _instance;
            }
        }
        
        public DbSet<User> Users { get; set; }

        protected UserContext() : base("Data Source=(local);Initial Catalog=StudentInfoDatabase;Integrated Security=True")
        {
        }
    }
}
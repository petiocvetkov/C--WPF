using System.Data.Entity;
using UserLogin;

namespace StudentRepository
{
    public class StudentInfoContext : DbContext
    {
        private static StudentInfoContext _instance = null;

        public static StudentInfoContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StudentInfoContext();
                return _instance;
            }
        }
        public DbSet<Student> Students { get; set; }

        public StudentInfoContext() : base(
            "Data Source=(local);Initial Catalog=StudentInfoDatabase;Integrated Security=True")
        {
        }
    }
}
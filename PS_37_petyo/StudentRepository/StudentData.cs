using System.Collections.Generic;
using System.Linq;

namespace StudentRepository
{
    public class StudentData
    {
        public List<Student> TestStudents => StudentInfoContext.Instance.Students.ToList();

        public StudentData()
        {
        }

        public static void AddStudents()
        {
            var studentInfoContext = StudentInfoContext.Instance;
            if (studentInfoContext.Students.Count() > 0)
            {
                return;
            }

            studentInfoContext.Students.AddRange(new List<Student>()
            {
                new Student()
                {
                    FirstName = "Admin",
                    MiddleName = "Admin",
                    LastName = "Admin",
                    FacultyNumber = "123456789",
                    Course = 3,
                    Degree = "test",
                    Faculty = "test",
                    Group = 51,
                    Specialty = "test",
                    Status = "test",
                    Flow = 2
                }
            });
            studentInfoContext.SaveChanges();
        }

        public Student IsThereStudent(string facultyNumber)
        {
            return TestStudents
                .Where(x => x.FacultyNumber == facultyNumber)
                .FirstOrDefault();
        }
    }
}
using UserLogin;

namespace StudentRepository
{
    public class StudentValidation
    {
        private readonly StudentData studentData = new StudentData();
        
        public delegate void ActionOnError(string errorMessage);

        private ActionOnError _errorFunc;

        public StudentValidation(ActionOnError errorFunc)
        {
            _errorFunc = errorFunc;
        }

        public Student GetStudentDataByUser(User user)
        {
            if (string.IsNullOrEmpty(user.FacNumber) || user == null)
            {
                _errorFunc("User is not found");
                return null;
            }

            var studentRecord = studentData.IsThereStudent(user.FacNumber);

            if (studentRecord == null)
            {
                _errorFunc("User is not found");
                return null;
            }

            return studentRecord;
        }
    }
}
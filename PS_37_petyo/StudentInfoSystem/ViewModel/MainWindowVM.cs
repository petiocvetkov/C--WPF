namespace StudentInfoSystem.ViewModel
{
    public class MainWindowVM
    {
        private StudentRepository.Student student;
        public StudentRepository.Student Student
        {
            get
            {
                return this.student;
            }
            set
            {
                student = value;
            }
        }

        public MainWindowVM(StudentRepository.Student student)
        {
            this.student = student;
        }
    }
}
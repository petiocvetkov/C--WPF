using System.Windows;
using StudentRepository;
using UserLogin;

namespace StudentInfoSystem
{
    public partial class Login : Window
    {
        private StudentValidation _validation;

        public Login()
        {
            InitializeComponent();
            _validation = new StudentValidation(message => MessageBox.Show(message));
            UserData.ResetTestUserData();
            StudentData.AddStudents();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtInputUserName.Text;
            string password = txtInputPassword.Text;
            var validation = new LoginValidation(username, password, message => { MessageBox.Show(message); });

            User user = null;
            if (validation.ValidateUserInput(ref user))
            {
                Student student = _validation.GetStudentDataByUser(user);
                if (student != null)
                {
                    new MainWindow(student).Show();
                    this.Close();
                }
            }
        }
    }
}
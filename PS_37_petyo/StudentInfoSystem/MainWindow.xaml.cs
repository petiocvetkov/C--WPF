using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StudentInfoSystem.ViewModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using EasyMVVM.Annotations;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private MainWindowVM viewModel;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> StudStatusChoices { get; set; }
        
        public MainWindow(StudentRepository.Student student)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            viewModel = new MainWindowVM(student);
            fillStudentData();
        }
        
        
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
                SqlConnection("Data Source=(local);Initial Catalog=StudentInfoDatabase;Integrated Security=True"))
            {
                string sqlquery =
                    @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private void BtnClearData_Click(object sender, RoutedEventArgs e)
        {
            txtCourse.Text = "";
            txtDegree.Text = "";
            txtFaculty.Text = "";
            txtFacultyNumber.Text = "";
            txtFirstName.Text = "";
            txtGroup.Text = "";
            txtLastName.Text = "";
            txtSpecialty.Text = "";
            txtStream.Text = "";
            txtSurName.Text = "";
        }

        private void BtnFillData_Click(object sender, RoutedEventArgs e)
        {
            fillStudentData();
        }

        private void fillStudentData()
        {
            txtCourse.Text = viewModel.Student.Course.ToString();
            txtDegree.Text = viewModel.Student.Degree;
            txtFaculty.Text = viewModel.Student.Faculty;
            txtFacultyNumber.Text = viewModel.Student.FacultyNumber;
            txtFirstName.Text = viewModel.Student.FirstName;
            txtGroup.Text = viewModel.Student.Group.ToString();
            txtLastName.Text = viewModel.Student.LastName;
            txtSpecialty.Text = viewModel.Student.Specialty;
            txtStream.Text = viewModel.Student.Flow.ToString();
            txtSurName.Text = viewModel.Student.MiddleName;
        }

        private void BtnDisableInputs_Click(object sender, RoutedEventArgs e)
        {
            EnableInputFields(false);
        }

        private void BtnEnableInputs_Click(object sender, RoutedEventArgs e)
        {
            EnableInputFields(true);
        }

        private void EnableInputFields(bool enabled)
        {
            txtCourse.IsEnabled = enabled;
            txtDegree.IsEnabled = enabled;
            txtFaculty.IsEnabled = enabled;
            txtFacultyNumber.IsEnabled = enabled;
            txtFirstName.IsEnabled = enabled;
            txtGroup.IsEnabled = enabled;
            txtLastName.IsEnabled = enabled;
            txtSpecialty.IsEnabled = enabled;
            txtStream.IsEnabled = enabled;
            txtSurName.IsEnabled = enabled;
        }
    }
}
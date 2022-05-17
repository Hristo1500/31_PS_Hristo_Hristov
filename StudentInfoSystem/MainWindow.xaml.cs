using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Student Student;

        

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {

            Student = new Student();
            DataContext = Student;
            InitializeComponent();
            if (TestStudentsIfEmpty())
            {
                this.CopyTestStudents();
            }
        }

        public void FillStudStatusChoices(Student student)
        {
            student.StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";

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
                    txtStatus.Items.Add(s);
                    notEndOfResult = reader.Read();
                }
            }

        }

        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();

            if (countStudents == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            StudentData studentData = new StudentData();

            foreach (var student in studentData.getStudents())
            {
                context.Students.Add(student);
            }

            context.SaveChanges();
        }


        private void clear()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
            }
        }

        private void setStudent(Student student)
        {
            if (isStudentDataCorrect(student))
            {
                enableControls();
                fillStudentInfo(student);
            }
            else
            {
                clear();
                disableControls();
            }

        }

        private Boolean isStudentDataCorrect(Student student)
        {
            return student != null && !String.IsNullOrWhiteSpace(student.FirstName) && !String.IsNullOrWhiteSpace(student.SecondName) && !String.IsNullOrWhiteSpace(student.LastName)
                && !String.IsNullOrWhiteSpace(student.Faculty) && !String.IsNullOrWhiteSpace(student.Speciality) && !String.IsNullOrWhiteSpace(student.Degree)
                && !String.IsNullOrWhiteSpace(student.Status) && !String.IsNullOrWhiteSpace(student.FacultyNumber) && student.Course != 0
                && student.Flow != 0 && student.Group != 0;
        }

        private void fillStudentInfo(Student student)
        {
            this.Student = student;

            txtFirstName.Text = this.Student.FirstName;
            txtSecondName.Text = this.Student.SecondName;
            txtLastName.Text = this.Student.LastName;
            txtFaculty.Text = this.Student.Faculty;
            txtSpeciality.Text = this.Student.Speciality;
            txtDegree.Text = this.Student.Degree;
            txtStatus.Text = this.Student.Status;
            txtFacultyNumber.Text = this.Student.FacultyNumber;
            txtCourse.Text = Convert.ToString(this.Student.Course);
            txtFlow.Text = Convert.ToString(this.Student.Flow);
            txtGroup.Text = Convert.ToString(this.Student.Group);
        }
       
        private void disableControls()
        {
            foreach (Control ctr in MainGrid.Children)
            {
                if (ctr.Name == "btnUnlock" || ctr.Name == "btnTest")
                {
                    ctr.IsEnabled = true;
                }
                else
                {
                    ctr.IsEnabled = false;
                }
            }
        }

        private void enableControls()
        {
            foreach (Control ctr in MainGrid.Children)
            {
                ctr.IsEnabled = true;
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            StudentData data = new StudentData();
            setStudent(data.getStudents().First());
        }

        private void btnTest2_Click(object sender, RoutedEventArgs e)
        {
            setStudent(null);
        }

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            disableControls();
        }

        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {
            enableControls();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Owner = this;
            loginWindow.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                bool test = this.TestStudentsIfEmpty();
                MessageBox.Show(test.ToString());
            
        }
    }
}

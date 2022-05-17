using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public Student Student { get; set; }

        public string FirstName { get; set; }
        public string FacNumber { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentValidation studentValidation = new StudentValidation();
            Student = studentValidation.GetStudentDataByNameAndFacNum(FirstName, FacNumber);
            if (Student != null)
            {
                MainWindow mainWindow = Owner as MainWindow;
                mainWindow.Student.FirstName = this.Student.FirstName;
                mainWindow.Student.SecondName = Student.SecondName;
                mainWindow.Student.LastName = Student.LastName;
                mainWindow.Student.Faculty = Student.Faculty;
                mainWindow.Student.Speciality = Student.Speciality;
                mainWindow.Student.Degree = Student.Degree;
                mainWindow.Student.Status = Student.Status;
                mainWindow.Student.FacultyNumber = Student.FacultyNumber;
                mainWindow.Student.Course = Student.Course;
                mainWindow.Student.Flow = Student.Flow;
                mainWindow.Student.Group = Student.Group;
                mainWindow.FillStudStatusChoices(Student);
                mainWindow.Student.StudStatusChoices = Student.StudStatusChoices;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не съществува такъв студент!");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student : INotifyPropertyChanged
    {

        private string _firstName;
        private string _secondName;
        private string _lastName;
        private string _faculty;
        private string _speciality;
        private string _degree;
        private string _status;
        private string _facultyNumber;
        private int _course;
        private int _flow;
        private int _group;
        private List<string> _studStatusChoices;
        public int StudentId { get; set; }
        public List<string> StudStatusChoices
        {
            get { return _studStatusChoices; }
            set 
            { 
                if( _studStatusChoices != value)
                {
                    _studStatusChoices = value;
                    OnPropertyChanged("Status Choices");
                }

            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }

        }
        public string SecondName
        {
            get
            {
                return _secondName;
            }
            set
            {
                if (_secondName != value)
                {
                    _secondName = value;
                    OnPropertyChanged("SecondName");
                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        public string Faculty
        {
            get { return _faculty; }
            set
            {
                if (_faculty != value)
                {
                    _faculty = value;
                    OnPropertyChanged("Faculty");
                }
            }
        }
        public string Speciality
        {
            get { return _speciality; }
            set
            {
                if (_speciality != value)
                {
                    _speciality = value;
                    OnPropertyChanged("Speciality");
                }
            }
        }
        public string Degree
        {
            get { return _degree; }
            set
            {
                if (_degree != value)
                {
                    _degree = value;
                    OnPropertyChanged("Degree");
                }
            }
        }
        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        public string FacultyNumber
        {
            get { return _facultyNumber; }
            set
            {
                if (_facultyNumber != value)
                {
                    _facultyNumber = value;
                    OnPropertyChanged("FacultyNumber");
                }
            }
        }
        public int Course
        {
            get { return _course; }
            set
            {
                if (_course != value)
                {
                    _course = value;
                    OnPropertyChanged("Course");
                }
            }
        }
        public int Flow
        {
            get { return _flow; }
            set
            {
                if (_flow != value)
                {
                    _flow = value;
                    OnPropertyChanged("Flow");
                }
            }
        }
        public int Group
        {
            get { return _group; }
            set
            {
                if (_group != value)
                {
                    _group = value;
                    OnPropertyChanged("Group");
                }
            }
        }

        public byte[] Photo { get; set; }

        public Student()
        {

        }

        public Student(string firstName, string secondName, string lastName, string faculty, string speciality,string degree, string status,
            string facultyNumber, int course, int flow, int group)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.LastName = lastName;
            this.Faculty = faculty;
            this.Speciality = speciality;
            this.Degree = degree;
            this.Status = status;
            this.FacultyNumber = facultyNumber;
            this.Course = course;
            this.Flow = flow;
            this.Group = group;

            OnPropertyChanged("Student");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private LoginCommand _loginCommand = new LoginCommand();
        public LoginCommand LoginCommand
        {
            get { return _loginCommand; }
        }

        public override string ToString() { return this.FirstName; }
    }
}

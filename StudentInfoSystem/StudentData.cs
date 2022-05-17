using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class StudentData
    {
        public List<Student> TestStudents;
        public StudentData()
        {
            TestStudents = new List<Student>();
            TestStudents.Add(exampleStudent());

        }
        public List<Student> getStudents()
        {
            return this.TestStudents;
        }

        private void setStudents(List<Student> students)
        {
            this.TestStudents = students;
        }

        private Student exampleStudent()
        {
            Student student = new Student("Hristo", "Ivanov", "Hristov", "FCST", "CSE", "Bachelor", "Certified",
                "121219066", 4, 3, 31);

            return student;
        }

    }
}

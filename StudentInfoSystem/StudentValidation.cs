using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        private StudentInfoContext _studentInfoContext = new StudentInfoContext();
        public Student GetStudentDataByUser(User user)
        {
            Student student = _studentInfoContext.Students
                            .Where(w => w.FacultyNumber == user.facNumber)
                            .FirstOrDefault();

            if (student != null)
            {
                return student;
            }

            return null;
        }

        public Student GetStudentDataByNameAndFacNum(string firstName, string facNumber)
        {
            Student student = _studentInfoContext.Students.Where(w => w.FacultyNumber == facNumber && w.FirstName == firstName).FirstOrDefault();
            return student != null ? student : null;
        }
    }
}

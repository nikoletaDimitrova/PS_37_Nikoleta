using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public Student GetStudentDataByUser(User User1)
        {
            Student student = new Student();
            if(User1.StudentID == null)
            {
                Console.WriteLine("StudentId not provided");
                return null;
            }
            student.FacltId = User1.StudentID;
            return student;
        }
    }
}

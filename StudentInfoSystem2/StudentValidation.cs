using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        List<UserLogin.User> Students1 = null;
        public Student GetStudentDataByUser(UserLogin.User User1)
        {
            UserLogin.UserData.ResetTestUserData();
            Students1 = UserLogin.UserData.TestUsers;
            Student student = new Student();
            if(User1.StudentID != null)
            {
                for(int i= 0; i< Students1.Count; i++)
                {
                    if (User1.StudentID.Equals(Students1.ElementAt(i)))
                    {
                        student.FacltId = User1.StudentID;
                        student.FirstName = User1.Name;
                        return student;
                    }
                }
            }
            Console.WriteLine("StudentId not provided");
            return null;
        }
    }
}

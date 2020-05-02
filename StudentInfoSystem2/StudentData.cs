using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    static class StudentData
    {
    
        public static MainFormVM TestStudent
        {
            private set;
            get;
        }

        public static List<Student> TestStudents
        {
            get
            {
                return PopulateStudents();
            }
            set { }
        }

          
        private static List<Student> PopulateStudents()
        {
            List<Student> students = new List<Student>();
            Student student1 = new Student();
            student1.FirstName = "Nikoleta";
            student1.SecondName = "Ionkova";
            student1.LastName = "Dimitrova";
            students.Add(student1);
            Student student2 = new Student();
            student1.FirstName = "Gabriela";
            student1.SecondName = "Ionkova";
            student1.LastName = "Dimitrova";
            students.Add(student2);
            return students;
        }
    }
}

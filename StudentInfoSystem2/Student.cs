using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string FacltId { get; set; }
        public string FacultetName { get; set; }
        public string Speciality { get; set; }
        public string Degree { get; set; }
        public string Status { get; set; }
        public string YearInUni { get; set; }
        public string Group { get; set; }
        public string GroupFlow { get; set; }
        public byte[] Photo { get; set; }
    }
}

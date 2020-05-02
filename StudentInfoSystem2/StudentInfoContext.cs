using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentInfoContext : DbContext
    {
        public StudentInfoContext()
          : base("Data Source = (local); Initial Catalog = StudentInfoDatabase; Integrated Security = True")
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

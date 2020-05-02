using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace UserLogin
{
    class UserContext : DbContext
    {
        public UserContext()
          : base("Data Source = (local); Initial Catalog = StudentInfoDatabase; Integrated Security = True")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}

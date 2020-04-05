using System;

namespace UserLogin
{
    public class User
    {

        public String Name
        {
            get; set;
        }

        public String Pass
        {
            get; set;
        }
        public String StudentID
        {
            get; set;
        }
        public Int32 Role
        {
            get; set;
        }

        public DateTime Created
        {
            get; set;
        }

        public DateTime ExpirationDate
        {
            get; set;
        }
    }
}

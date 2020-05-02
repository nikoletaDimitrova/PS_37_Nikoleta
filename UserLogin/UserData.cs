using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLogin
{
    static public class UserData
    {
        private static UserContext context = new UserContext();
        static public List<User> TestUsers
        {
            get {
                ResetTestUserData();
                return _testUsers;
            }
            set {}
        }
        static List<User> _testUsers = null;

        static public void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>();
                User user1 = new User();
                user1.Name = "Nikoleta";
                user1.Pass = "12345";
                user1.Role = 1;
                user1.StudentID = "123AB";
                user1.Created = DateTime.Now;
                user1.ExpirationDate = DateTime.MaxValue;
                _testUsers.Add(user1);

                User user2 = new User();
                user2.Name = "Teodor";
                user2.Pass = "1reeeee";
                user2.Role = 4;
                user2.StudentID = "124AC";
                user2.Created = DateTime.Now;
                user2.ExpirationDate = DateTime.MaxValue;
                _testUsers.Add(user2);

                User user3 = new User();
                user3.Name = "Marina";
                user3.Pass = "be23456";
                user3.Role = 4;
                user3.StudentID = "124AD";
                user3.Created = DateTime.Now;
                user3.ExpirationDate = DateTime.MaxValue;
                _testUsers.Add(user3);
            }
        }

        static public User IsUserPassCorrect(string UserName, string Password)
        {
            foreach(User _searchedUser in context.Users)
            {
                if (UserName.Equals(_searchedUser.Name) && Password.Equals(_searchedUser.Pass)){
                    return _searchedUser;
                }
            }
            return null;

        }
        static public void SetUserActiveTo(string UserName, DateTime ExpirationDate)
        {
            User existingUser = SearchByName(UserName);
                    existingUser.ExpirationDate = ExpirationDate;
            Logger.LogActivity("Successful expiration change to " + UserName);

        }

        static public void AssignUserRole(string UserName, int role)
        {
            User existingUser = SearchByName(UserName);
            existingUser.Role = role;
            UserContext context = new UserContext();
            User usr =
            (from u in TestUsers
             where u.UserId == existingUser.UserId
             select u).First();
            usr.Role = role;
            context.SaveChanges();
            Logger.LogActivity("Successful role change to " + UserName);

        }

        static private User SearchByName(String _userName)
        {
            foreach (User _searchedUser in _testUsers)
            {
                if (_userName.Equals(_searchedUser.Name))
                {
                    return _searchedUser;
                }
            }
            return null;
        }
    }
}

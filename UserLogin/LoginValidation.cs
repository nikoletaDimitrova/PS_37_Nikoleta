using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
     public class LoginValidation
    {
        private string UserName;
        private string Password;
        private string ErrorMessage;
        public static int failedLogin;
        public static bool isLogged = false;
        public static bool closedLogging = false;

        public delegate void ActionError(string ErrorMessage);
        private ActionError _actionError;

        public LoginValidation(string UserName, string Password, ActionError _actionError)
        {
            this.UserName = UserName;
            this.Password = Password;
            this._actionError = _actionError;

        }

        static public UserRoles currentUserRoles
        {
            private set;
            get;
        }

        static public string currentUserName
        {
            get; private set;
        }

        public Boolean ValidateUserInput(User user1)
        {
            if(failedLogin == 2)
            {
                Console.WriteLine("You cannot login anymore");
                closedLogging = true;
                return false;
            }

            if (UserName.Equals(String.Empty))
            {
                ErrorMessage = "Username should be provided";
                   failedLogin += 1;
                return false;
             }

            if(UserName.Length < 5)
            {
                ErrorMessage = "Username should be more than or equal to 5 signs";
                failedLogin += 1;
                return false;

            }
            if (Password.Equals(String.Empty))
            {
                ErrorMessage = "Password should be provided";
                failedLogin += 1;
                return false;
            }
            if (Password.Length < 5)
            {
                ErrorMessage = "Password should be more than or equal to 5 signs";
                failedLogin += 1;
                return false;
            }
            _actionError(ErrorMessage);
            User existingUser = UserData.IsUserPassCorrect(UserName, Password);
            user1.Name = existingUser.Name;
            user1.Pass = existingUser.Pass;
            user1.StudentID = existingUser.StudentID;
            user1.Role = existingUser.Role;
            if (user1 == null)
            {
                ErrorMessage = "There is no user with that name and pass";
                currentUserRoles = UserRoles.ANONIMOUS;
                return false;
            }
            currentUserName = user1.Name;
            currentUserRoles = (UserRoles)user1.Role;
            isLogged = true;
            Logger.LogActivity("Succesfull Login");
            return true;
        }
    }

}

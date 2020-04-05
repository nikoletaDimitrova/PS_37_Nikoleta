using System;
using System.Text;

namespace UserLogin
{
    class Program
    {
        static void ActionErrorLog(string ErrorMessage)
        {
            Console.WriteLine("!!! " + ErrorMessage + " !!!");
        }

        static LoginValidation LoginCredentials()
        {
            Console.WriteLine("Name:");
            string Name = Console.ReadLine();
            Console.WriteLine("Password:");
            string Password = Console.ReadLine();
            UserData.ResetTestUserData();
            return new LoginValidation(Name, Password, ActionErrorLog);
        }
        static void AdministratorMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select option: \n" +
                "0: Exit \n" +
                "1: Change user role \n" +
                "2: Change user expiration date\n" +
                "3: List of users\n" +
                "4: Read Log File \n");
            sb.Append("5: Current Log Activity \n");
            Console.WriteLine(sb);


            string option = Console.ReadLine();
            switch (option)
            {
                case "0":
                    Console.WriteLine("Bye");
                    break;

                case "1":
                    Console.WriteLine("Write username you want to change:");
                    string UserName = Console.ReadLine();
                    Console.WriteLine("Write number of role you want to give: \n" +
                        "0:ANONIMOUS \n" +
                        "1:ADMIN \n" +
                        "2:INSPECTOR \n" +
                        "3:PROFESSOR \n" +
                        "4:STUDENT \n");
                    int role1 = Convert.ToInt32(Console.ReadLine());
                    UserData.AssignUserRole(UserName, role1);
                    break;

                case "2":
                    Console.WriteLine("Write username you want to change:");
                    string _userName = Console.ReadLine();
                    Console.WriteLine("Write the expiry date to change: ");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                    UserData.SetUserActiveTo(_userName, date);
                    break;

                case "4":
                    Logger.ReadLogFile();
                    break;
            }

        }
        static void Main(string[] args)
        {
            //Little excercise  
            // UserData.ResetTestUserData();
            //DateTime dt = new DateTime(2017, 9, 15, 10, 30, 0);
            //Console.WriteLine(dt.Hour);
            //DateTime now = DateTime.Today;
            //Console.WriteLine(now.Hour);
            //DateTime addedHoursDate = now.AddHours(12);
            //Console.WriteLine(addedHoursDate.Date);
            //Console.WriteLine("Add date here:");
            // string addedDate = Console.ReadLine();
            // DateTime convertedDate = Convert.ToDateTime(addedDate);

            //The program
            User User = new User();
            DateTime startTime = DateTime.Now;
            while (!LoginValidation.isLogged)
            {
                TimeSpan remainingTime = startTime.Subtract(DateTime.Now);
               if(remainingTime.TotalMinutes == 2.00 || LoginValidation.closedLogging)
                {
                    Console.WriteLine("Session expired you cannot log anymore");
                    break;
                }

                LoginValidation validation = LoginCredentials();
                if (validation.ValidateUserInput(User) )
                {
                    Console.WriteLine("name: " + User.Name + " pass: " + User.Pass + " role: " + User.Role + " studentId:" + User.StudentID);
                    Console.WriteLine(LoginValidation.currentUserRoles);

                    switch (LoginValidation.currentUserRoles)
                    {
                        case UserRoles.ADMIN:
                            Console.WriteLine("Welcome Admin");
                            AdministratorMenu();
                            break;

                        case UserRoles.ANONIMOUS:
                            Console.WriteLine("Welcome Anonimous");
                            break;
                        case UserRoles.INSPECTOR:
                            Console.WriteLine("Welcome Inspector");
                            break;
                        case UserRoles.PROFESSOR:
                            Console.WriteLine("Welcome Professor");
                            break;
                        case UserRoles.STUDENT:
                            Console.WriteLine("Welcome Student");
                            break;
                    }
                }
            }
        }
    }
}   

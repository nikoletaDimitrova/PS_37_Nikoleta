using StudentInfoSystem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
     {
            public Window1()
            {
                InitializeComponent();
            }
            public static void ShowActionErrorMessage(string errorMsg)
            {
                MessageBox.Show(errorMsg);
            }

            private void logButt_Click(object sender, RoutedEventArgs e)
            {
                string username = loginInfo.Text;
                string password = passwordUser.Password;
                LoginValidation validation = new LoginValidation(username, password, ShowActionErrorMessage);
                User user = new User();
                if (validation.ValidateUserInput(user))
                {
                    try
                    {
                    UserLogin.User userLogin = new UserLogin.User();
                    StudentValidation studentValidation = new StudentValidation();
                    Student student = studentValidation.GetStudentDataByUser(userLogin);
                        MainWindow mainWindow = new MainWindow(student);
                        mainWindow.Show();
                        Close();
                    }
                    catch
                    {
                        invalidCredentials();
                    }
                }
            }
            private void invalidCredentials()
            {
                MessageBox.Show("Invalid username or password!");
                TextBox usernameBox = loginInfo;
                usernameBox.Clear();
                PasswordBox passBox = passwordUser;
                passBox.Clear();
            }
        }
    }

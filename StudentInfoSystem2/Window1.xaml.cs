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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string userName = loginInfo.Text;
            string pass = usernameInput.Text;
            UserLogin.LoginValidation validation = new UserLogin.LoginValidation(userName, pass, ActionErrorLog);
            UserLogin.User someUser = new UserLogin.User();
            someUser.Name = userName;
            someUser.Pass = pass;
            if (!validation.ValidateUserInput(someUser))
            {
                MessageBox.Show("Wrong");
            }
        }

        static void ActionErrorLog(string ErrorMessage)
        {
            Console.WriteLine("!!! " + ErrorMessage + " !!!");
        }

        private void logButt_Click(object sender, RoutedEventArgs e)
        {
            StudentInfoSystem.MainWindow main = new StudentInfoSystem.MainWindow();
            main.Show();
          
        }
    }
}

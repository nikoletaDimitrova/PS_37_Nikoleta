using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(object data) : this()
        {
            MainFormVM mainFormVM = new MainFormVM();
            mainFormVM.CurrentStudent = (Student)data;
            Title = mainFormVM.Title;
            FillStudStatusChoices();
            this.DataContext = this;
            // this.DataContext = mainFormVM;
        }

        public List<string> StudStatusChoices { get; set; }

        private void ResetFields(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.Clear();
                }
            }
        }

        private void DisableAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.IsEnabled = false;
                }
            }
        }

        private void EnableAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.IsEnabled = true;
                }
            }
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new SqlConnection("Data Source=(local);Initial Catalog=StudentInfoDatabase;Integrated Security=True"))
            {

                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        Boolean TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if(countStudents == 0)
            {
                return true;
            }
            else { return false;}
        }

        Boolean TestUsersIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<User> queryUsers = context.Users;
            int countUsers = queryUsers.Count();
            if (countUsers == 0)
            {
                return true;
            }
            else { return false; }
        }

        void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
        }

        void CopyTestUsers()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (User st in UserData.TestUsers)
            {
                context.Users.Add(st);
            }
            context.SaveChanges();
        }

        private void testBtn_Click(object sender, RoutedEventArgs e)
        {
            Boolean result = TestStudentsIfEmpty();
            if (TestStudentsIfEmpty())
                CopyTestStudents();
            MessageBox.Show(result.ToString());
        }
    }
}
   
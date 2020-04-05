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

namespace WpfHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            listPeople.Items.Add(james);
            listPeople.SelectedItem = james;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            {
                foreach (var item in MainGrid.Children)
                {
                    if (item is TextBox)
                    {
                        s = s + ((TextBox)item).Text;
                        s = s + '\n';
                    }
                }
                MessageBox.Show("Здрасти!!! " + s + "Това е твоята първа програма на Visual Studio 2019!");
            }
            string greetingMsg;
            greetingMsg = listPeople.SelectedItem.ToString();
            MessageBox.Show("Hi " + greetingMsg);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (userName.Text.Length < 2)
            {
                MessageBox.Show("Username cannot be less than 2 symbols.");
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void messageButton_Click(object sender, RoutedEventArgs e)
        {        }
    }
}

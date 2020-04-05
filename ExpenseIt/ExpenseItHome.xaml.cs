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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExpenseIt
{

    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window
    {
        private DateTime lastChecked;
        public DateTime LastChecked {
            get { return lastChecked; } set { lastChecked = value;
            } }
       public ObservableCollection<string> PersonsChecked
         { get; set;}
        public ExpenseItHome()
        {
            PersonsChecked = new ObservableCollection<string>();
            LastChecked = DateTime.Now;
            this.DataContext = this;
            peopleListBox = new ListBox();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            ListBoxItem mike = new ListBoxItem();
            mike.Content = "Mike";
            ListBoxItem lisa = new ListBoxItem();
            lisa.Content = "Lisa";
            ListBoxItem john = new ListBoxItem();
            john.Content = "John";
            ListBoxItem mary = new ListBoxItem();
            mary.Content = "Mary";
            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(james);
            peopleListBox.Items.Add(mike);
            peopleListBox.Items.Add(lisa);
            peopleListBox.Items.Add(john);
            peopleListBox.Items.Add(mary);
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;
            InitializeComponent();

        }

        private void view_Click(object sender, RoutedEventArgs e)
        {
            ExpenseIt.ExpenseReport expenseReport= new ExpenseIt.ExpenseReport(sender);
            expenseReport.Height = this.Height;
            expenseReport.Width = this.Width;
            expenseReport.ShowDialog();
            PersonsChecked.Add((peopleListBox.SelectedItem as System.Xml.XmlElement).Attributes["Name"].Value);
        }
        private void peopleListBox_SelectionChanged_1(object sender,SelectionChangedEventArgs e)
        {
         PersonsChecked.Add(peopleListBox.SelectedItem.ToString());
            LastChecked = DateTime.Now;
        }
    }
}

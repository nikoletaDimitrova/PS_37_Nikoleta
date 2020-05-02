using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace WpfExample
{
    class MainWindowViewModel: INotifyPropertyChanged
    {

        private bool canExecute = true;
        private string date;
        public event PropertyChangedEventHandler PropertyChanged;
        public String BoundProperty
        {
            get;      
            set;
        }
        private void OnPropertyChanged(String property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public string Date
        {
            get { return this.date; }
            set { this.date = value; OnPropertyChanged("Date"); }
        }
        private ICommand hiButtonCommand;
        private ICommand toggleExecuteCommand
        { get; set; }
        public string HiButtonContent
        {
            get { return "click to hi"; }
        }

        public bool CanExecute
        {
            get { return this.canExecute; }
            set
            {
                if (this.canExecute == value)
                { return; }
                this.canExecute = value;
            }
        }
        public ICommand ToggleExecuteCommand
        {
            get
            { return toggleExecuteCommand; }
            set
            { toggleExecuteCommand = value; }
        }
        public ICommand HiButtonCommand
        {
            get
            { return hiButtonCommand; }
            set
            { hiButtonCommand = value; }
        }

        public MainWindowViewModel()
        {
            HiButtonCommand = new RelayCommand(ShowTextMessage, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }
        public void ShowMessage(object obj)
        {
            //it is good we do this with binding to some control
            System.Windows.MessageBox.Show(obj.ToString());
        }

        public void ShowTextMessage(object obj)
        {
            this.Date = DateTime.Now.ToLongTimeString();
            //BoundProperty = "hello";  
           
         }
        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }
    }
}

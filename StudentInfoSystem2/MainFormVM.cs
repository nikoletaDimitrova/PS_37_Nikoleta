using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StudentInfoSystem
{

    public class MainFormVM : INotifyPropertyChanged
    {
        public Student _student;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get { return "Student Infromation System"; }
        }
        public Student CurrentStudent
        {
            get { return _student; }
            set
            {
                if (_student != value)
                {
                    _student = value;
                    OnPropertyChanged("CurrentStudent");
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

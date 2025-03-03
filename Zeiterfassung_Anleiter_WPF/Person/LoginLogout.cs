using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Zeiterfassung_Anleiter_WPF.Person
{
    public class LoginLogout : INotifyPropertyChanged
    {
        private int persons_id = 0;
        private string login = string.Empty;
        private string logout = string.Empty;
        private int day = 0;
        private int month = 0;
        private int year = 0;
        private string timeSpan = string.Empty;

        public int Persons_id
        {
            get { return persons_id; }
            set { persons_id = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged(); }
        }

        public string Logout
        {
            get { return logout; }
            set { logout = value; OnPropertyChanged(); }
        }

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public string TimeSpan
        {
            get { return timeSpan; }
            set { timeSpan = value; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

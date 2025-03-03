using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Zeiterfassung_Anleiter_WPF.Person
{
    public class Attendee : INotifyPropertyChanged
    {
        #region fields
        private int attendeeID = 0;
        private string attendeeNumber = "";
        private string firstname = "";
        private string lastname = "";
        private string beginMeasure = "";
        private string endMeasure = "";
        private DateTime beginWork;
        private DateTime endWork;
        private string condition = "";
        private int holidayTaken = 0;
        private double summaryHoursMonth = 0.00;
        private double summaryHoursWeek = 0.00;
        private DateTime summaryHoursDay;
        private string password = "";
        private string nonAttendance = "";
        private int summaryHolidays = 0;
        private int summaryWorkDays = 0;
        private ObservableCollection<LoginLogout>? loginlogoutattendee = new();
        #endregion

        #region properties
        public int AttendeeID
        {
            get { return attendeeID; }
            set { attendeeID = value; }
        }
        public string AttendeeNumber
        {
            get { return attendeeNumber; }
            set { attendeeNumber = value; }
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string BeginMeasure
        {
            get { return beginMeasure; }
            set { beginMeasure = value; }
        }

        public string EndMeasure
        {
            get { return endMeasure; }
            set { endMeasure = value; }
        }

        public DateTime BeginWork
        {
            get { return beginWork; }
            set { beginWork = value; }
        }

        public DateTime EndWork
        {
            get { return endWork; }
            set { endWork = value; }
        }

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        public int HolidayTaken
        {
            get { return holidayTaken; }
            set { holidayTaken = value; }
        }

        public double SummaryHoursMonth
        {
            get { return summaryHoursMonth; }
            set { summaryHoursMonth = value; }
        }

        public double SummaryHoursWeek
        {
            get { return summaryHoursWeek; }
            set { summaryHoursWeek = value; }
        }

        public DateTime SummaryHoursDay
        {
            get { return summaryHoursDay; }
            set { summaryHoursDay = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string NonAttendance
        {
            get { return nonAttendance; }
            set { nonAttendance = value; }
        }

        public int SummaryHolidays
        {
            get { return summaryHolidays; }
            set { summaryHolidays = value; }
        }

        public int SummaryWorkDays
        {
            get { return summaryWorkDays; }
            set { summaryWorkDays = value; }
        }

        

        public ObservableCollection<LoginLogout> LoginLogoutAttendee
        {
            get { return loginlogoutattendee!; }
            set
            {
                loginlogoutattendee = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

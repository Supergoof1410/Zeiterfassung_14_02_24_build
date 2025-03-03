using Microsoft.Data.Sqlite;
using System.Collections.ObjectModel;
using System.Windows;
using Zeiterfassung_Anleiter_WPF.Database.Connections;
using Zeiterfassung_Anleiter_WPF.Database.ReaderWriter;
using Zeiterfassung_Anleiter_WPF.Person;

namespace Zeiterfassung_Anleiter_WPF
{
    /// <summary>
    /// Interaktionslogik für addAttendee.xaml
    /// </summary>
    public partial class AddAttendee : Window
    {
        SqliteConnection? connection;
        SetSqliteQuery setInsert = new();
        GetSqliteQuery getAttendeeNumbers = new();
        ObservableCollection<AttendeeNumbersDB> numbersList = new();
        Attendee? attendee = null;
        ObservableCollection<Attendee> testData;
        //AttendeeNumbersDB attNumbers = new();

        public AddAttendee(SqliteConnection? sqliteConnect, ObservableCollection<Attendee> stringData)
        {
            if (sqliteConnect!.State == 0)
            {
                connection = SqliteConnect.ConnectSqlite(0);
            }
            else
            {
                connection = sqliteConnect;
            }
            testData = stringData;
            numbersList = getAttendeeNumbers.GetAttendeeNumbers(connection!, numbersList, true);

            InitializeComponent();

            ListTNNumbers();
        }

        private void doneAdd_Click(object sender, RoutedEventArgs e)
        {
            connection!.Close();
            this.DialogResult = true;
            this.Close();

        }

        private void nextAttendee_Click(object sender, RoutedEventArgs e)
        {
            attendee = new Attendee();
            attendee.AttendeeID = (int)attendeeNumber.SelectedItem;
            attendee.AttendeeNumber = numbersList.ElementAt(attendeeNumber.SelectedIndex).AttendeeNumber;
            attendee.Lastname = lastname.Text;
            attendee.Firstname = firstname.Text;
            attendee.Password = passwd.Text;
            attendee.BeginMeasure = BeginMeasure.SelectedDate!.Value.ToShortDateString();
            attendee.EndMeasure = EndMeasure.SelectedDate!.Value!.ToShortDateString();
            // FIXME 
            attendee.Condition = "Z3";
            attendee.BeginWork = Convert.ToDateTime(beginWork.Text);
            attendee.EndWork = Convert.ToDateTime(endWork.Text);
            attendee.SummaryHoursDay = Convert.ToDateTime(summaryDay.Text);
            attendee.SummaryWorkDays = Convert.ToInt32(workDays.Text);

            for (int days = 1; days < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); days++)
            {
                LoginLogout log = new();
                log.Year = DateTime.Now.Year;
                log.Month = DateTime.Now.Month;
                log.Day = days;
                log.Persons_id = attendee.AttendeeID;
                attendee.LoginLogoutAttendee.Add(log);
            }

            testData.Add(attendee);

            if (setInsert.InsertPerson(connection!, attendee))
            {
                numbersList.ElementAt(attendeeNumber.SelectedIndex).IsSet = true;
                ClearValues();
            }

        }
        private void ClearValues()
        {

            ListTNNumbers();

            attendeeNumber.SelectedIndex = 0;
            lastname.Text = string.Empty;
            firstname.Text = string.Empty;
            passwd.Text = string.Empty;
            condition.SelectedIndex = 0;
            beginWork.Text = string.Empty;
            endWork.Text = string.Empty;
            BeginMeasure.Text = string.Empty;
            EndMeasure.Text = string.Empty;
            workDays.Text = string.Empty;
            summaryDay.Text = string.Empty;
        }
        private void ListTNNumbers()
        {
            attendeeNumber.Items.Clear();

            try
            {
                foreach (var number in numbersList)
                {
                    if (number.IsSet != false)
                    {
                        continue;
                    }

                    attendeeNumber.Items.Add(number.AttendeeID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                connection!.Close();
            }
        }
    }
}

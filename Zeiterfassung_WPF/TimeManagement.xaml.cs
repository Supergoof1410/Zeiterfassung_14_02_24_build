using Arbeitszeiterfassung_TN.TimeManager;
using Microsoft.Data.Sqlite;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Zeiterfassung_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class TimeManagement : Window
    {
        DateTime dtGer;
        readonly SqliteConnection? sqliteConn;
        GetSqliteQuery getSqliteQuery = new GetSqliteQuery();
        SetSqliteQuery setSqliteQuery = new SetSqliteQuery();
        Person? personData;
        List<Person> listPeople = new List<Person>();
        //List<Person> listTest = new List<Person>();
        //List<Person> listPeopleBetween = new List<Person>();

        public string? FullName { get; set; }

        #region Main Window
        public TimeManagement()
        {
            Login loginWindow = new Login();
            bool? result = loginWindow.ShowDialog();

            if (result!.Value == true)
            {
                personData = loginWindow.person;
            }
            else
            {
                loginWindow.Close();
                Application.Current.Shutdown();
                return;
            }

            sqliteConn = ConnectSqlite.ConnectToSqlite(@".\SqliteDB\Teilnehmer.db");

            InitializeComponent();

            GetTime();

            DataContext = this;

            listPeople = getSqliteQuery.GetDataPersonFirst(sqliteConn!, personData!);

            foreach (var minutesSummary in listPeople)
            {
                personData.SummaryHoursMonth += minutesSummary.SummaryHoursMonth;
            }

            //PersonToDatabase();

            lblLoginTime.Content = ""; //listPeople.Find(x => x.Tn_Value == personData.Tn_Value)!.LoginTime;
            lblLogoutTime.Content = ""; //listPeople.Find(x => x.Tn_Value == personData.Tn_Value)!.LogoutTime;

            //btnGoing.IsEnabled = false;
            //btnComing.IsEnabled = false;

            lblAllHours.Content = null;

            if (lblLoginTime.Content == null)
            {
                btnComing.IsEnabled = true;
                btnGoing.IsEnabled = false;
            }
            else
            {
                btnComing.IsEnabled = false;
                btnGoing.IsEnabled = true;
            }

            //this.IsEnabled = false;
        }
        #endregion

        // Buttons and labels for the timemangement form
        #region Buttons and labels
        private void BtnComing_Click(object sender, RoutedEventArgs e)
        {
            personData!.LoginTime = lblActualTime.Content.ToString();
            btnComing.IsEnabled = false;
            btnGoing.IsEnabled = true;
            lblLoginTime.Visibility = Visibility.Visible;

            lblLoginTime.Content = personData.LoginTime;
            lblLoginTime.Background = Brushes.Green;
            setSqliteQuery.SetPersonLoginLogout(sqliteConn!, personData, 1);
        }

        private void BtnGoing_Click(object sender, RoutedEventArgs e)
        {
            personData!.LogoutTime = lblActualTime.Content.ToString();
            personData.diffTime = CalculateDifferentWorkTime(personData.LoginTime!, personData.LogoutTime!);

            btnGoing.IsEnabled = false;
            lblLogoutTime.Visibility = Visibility.Visible;

            lblLogoutTime.Content = personData.LogoutTime;
            lblLogoutTime.Background = Brushes.Green;

            lblAllHours.Background = Brushes.Green;
            lblAllHours.Content = personData.diffTime;

            setSqliteQuery.SetPersonLoginLogout(sqliteConn!, personData, 2);
            setSqliteQuery.UpdateAttendeeTimeSpan(sqliteConn!, personData);
            DateTime minutes = Convert.ToDateTime(personData.diffTime);
            personData.SummaryHoursMonth += minutes.Minute + (minutes.Hour * 60);
            setSqliteQuery.UpdateAttendeeMonthHours(sqliteConn!, personData);
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            Monatsuebersicht month = new Monatsuebersicht(sqliteConn!, personData!);
            month.Show();
        }
        #endregion

        // Timemanagement form methods
        #region Methods
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Sets the person data for a new day
            // to database for the first program start
            #region Set person data to Object(Person)

            PersonToDatabase();

            #endregion

            lblAllHours.Background = Brushes.Green;
            txtName.TextWrapping = TextWrapping.Wrap;
            FullName = personData!.Firstname + " " + personData.Lastname + " (" + personData.Tn_Value + ")";
            txtName.Text = FullName;

            //this.IsEnabled = true;
        }

        private void timeMan_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(sqliteConn! != null) sqliteConn!.Close();
            WriteFile.WriteFiles(0, $"[{Environment.UserName}] Datenbank geschlossen!)");
        }
        #endregion

        // Generic methods
        #region Generic Methods
        internal void GetActualTime(object sender, EventArgs e)
        {
            dtGer = dtGer.AddSeconds(1);
            State.Text = dtGer.ToLongTimeString();
            lblActualTime.Content = Logging.LogInOut(dtGer).ToShortTimeString();
            //this.IsEnabled = true;
        }

        internal string CalculateDifferentWorkTime(string workBegin, string workEnd)
        {
            DateTime beginTime = Convert.ToDateTime(workBegin);
            DateTime endTime = Convert.ToDateTime(workEnd);

            TimeSpan differentTime = endTime - beginTime;

            return differentTime.ToString(@"hh\:mm");
        }

        internal void PersonToDatabase()
        {
            personData!.Day = dtGer.Day;
            personData.Month = dtGer.Month;
            personData.Year = dtGer.Year;

            //listPeople = getSqliteQuery.GetDataPersonFirst(sqliteConn!, personData);

            if (listPeople.Count == 0)
            {
                if (personData.LoginTime == null)
                {
                    setSqliteQuery.SetAttendeeFirstStart(sqliteConn!, personData!);
                }
            }
            else
            {
                setSqliteQuery.SetAttendeeFirstStart(sqliteConn!, personData!);
            }

            //listPeopleBetween = listPeople;
            //listPeople.Clear();

            //listPeople = getSqliteQuery.GetDataPersonFirst(sqliteConn!, personData);
            //listPeople = listPeopleBetween;
            // TODO -> because the first attendee must be filled-in to the DB from
            // the attendee-manager


            // FIXME please!!!!!!!!!!!! 01.02.24

            foreach (var item in listPeople)
            {

                personData.Firstname = item.Firstname;
                personData.Lastname = item.Lastname;
                personData.Tn_Value = item.Tn_Value;

                if (item.Day == DateTime.Today.Day && item.Month == DateTime.Today.Month && item.Year == DateTime.Today.Year)
                {

                    if (item.LoginTime != null)
                    {
                        btnComing.IsEnabled = false;
                        btnGoing.IsEnabled = true;
                        lblLoginTime.Content = item.LoginTime;
                        personData.LoginTime = item.LoginTime;
                        lblLoginTime.Background = Brushes.Green;
                    }
                    else
                    {
                        lblLoginTime.Content = "";
                        btnComing.IsEnabled = true;
                        btnGoing.IsEnabled= false;
                    }

                    if (item.LogoutTime != null)
                    {
                        btnGoing.IsEnabled = false;
                        lblLogoutTime.Content = item.LogoutTime;
                        lblLogoutTime.Background = Brushes.Green;
                    }
                    //else
                    //{
                    //    lblLogoutTime.Content = "";
                    //    btnGoing.IsEnabled = true;
                    //}

                    if (item.LoginTime != null && item.LogoutTime != null)
                    {
                        item.diffTime = CalculateDifferentWorkTime(item.LoginTime!, item.LogoutTime!);

                        setSqliteQuery.UpdateAttendeeTimeSpan(sqliteConn!, item);
                        lblAllHours.Content = item.diffTime;
                        lblAllHours.Background = Brushes.Green;
                        btnGoing.IsEnabled = false;
                        btnComing.IsEnabled = false;
                    }
                }
                else
                {
                    if (item.LoginTime != null & item.LogoutTime != null)
                    {
                        item.diffTime = CalculateDifferentWorkTime(item.LoginTime!, item.LogoutTime!);

                        setSqliteQuery.UpdateAttendeeTimeSpan(sqliteConn!, item);
                        setSqliteQuery.UpdateAttendeeMonthHours(sqliteConn!, personData);
                        lblAllHours.Background = Brushes.Green;
                        //btnGoing.IsEnabled = false;
                    }
                }
                //listTest.Add(item);
            }
        }
        #endregion

        internal void GetTime()
        {
            #region Get Date and time
            CultureInfo myCulture = new CultureInfo("de-DE");
            Stopwatch sw = new Stopwatch();

            sw.Start();
            dtGer = GetTimeActual.GetTime();
            sw.Stop();

            long elapsed = sw.ElapsedMilliseconds;

            //dtGer.AddMilliseconds(elapsed);

            DispatcherTimer timer1 = new()
            {
                Interval = new TimeSpan(0, 0, 1)
            };

            timer1.IsEnabled = true;
            timer1.Tick += new EventHandler(GetActualTime!);
            timer1.Start();

            lblActualDate.Content =
                $"{dtGer.ToString("ddd", CultureInfo.CurrentCulture)}, {dtGer.Day}. {dtGer.ToString("MMM", CultureInfo.CurrentCulture)} " +
                $"{dtGer.ToString("yyyy", CultureInfo.CurrentCulture)}";
            lblActualTime.Content = dtGer.ToShortTimeString();
            #endregion
        }

    }
}

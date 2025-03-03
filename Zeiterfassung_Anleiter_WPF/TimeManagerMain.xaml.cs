using Microsoft.Data.Sqlite;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Zeiterfassung_Anleiter_WPF.Database.Connections;
using Zeiterfassung_Anleiter_WPF.Database.ReaderWriter;
using Zeiterfassung_Anleiter_WPF.Person;

namespace Zeiterfassung_Anleiter_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TimeManagerMain : Window
    {
        private SqliteConnection? connection = null;
        private Stopwatch Stopwatch = new Stopwatch();
        GetSqliteQuery getDataAttendee = new();
        //Attendee attendee = new();
        ObservableCollection<Attendee> stringData = new();
        DataGridTemplateColumn TemplateColumn = new();
        int daysPerMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

        public TimeManagerMain()
        {
            Stopwatch.Start();

            connection = SqliteConnect.ConnectSqlite(0);

            DataContext = this;

            InitializeComponent();

            labelActualMonth.Content = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month) + " " +
                DateTime.Now.Year;

            DrawDataGrid();

            stringData = getDataAttendee.GetDataPersons(connection);



            attendeesList.ItemsSource = stringData;
           // attendeesList.DataContext = stringData;


            Stopwatch.Stop();

            StatusBar.Content = "Datenbank erstellt/gelesen in: " + Stopwatch.ElapsedMilliseconds + " ms";
        }

        #region Create DataTable
        //private DataTable TableOfData(ObservableCollection<Attendee> dataFromSql)
        //{
        //    DataTable table = new DataTable();

        //    table.Columns.Add("ID");
        //    table.Columns.Add("Lastname");
        //    table.Columns.Add("Firstname");
        //    table.Columns.Add("Password");

        //    for (int i = 1; i <= daysPerMonth; i++)
        //    {
        //        var day = i;
        //        var DayName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i).ToString("ddd");
        //        var stringDays = $"{DayName}, {day}.";
        //        table.Columns.Add(stringDays, typeof(string));
        //    }

        //    return table;
        //}
        #endregion

        #region Methods for draw the datagrid
        private void DrawDataGrid()
        {
            for (int i = 1; i <= daysPerMonth; i++)
            {
                var day = i;
                var DayName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i).ToString("ddd");

                

                TemplateColumn = new DataGridTemplateColumn()
                {
                    Header = $"{DayName}, {day}.",
                    //CellTemplate = (DataTemplate)Resources["CellLogging"]
                };

                attendeesList.Columns.Add(TemplateColumn);

                //if (DayName == "Sa" || DayName == "So") TemplateColumn.CellTemplate = (DataTemplate)Resources["Weekend"];
                //else TemplateColumn.CellTemplate = (DataTemplate)Resources["CellLogging"];

            }


            //attendeesList.ItemsSource = stringData;
        }
        #endregion

        private void AddAttendee_Click(object sender, RoutedEventArgs e)
        {
            Window addWindow = new AddAttendee(connection, stringData);
            var result = addWindow.ShowDialog();

            if (result!.Value)
            {
                attendeesList.Items.Refresh();
            }
        }

        #region Menu-Item about
        private void about_Click(object sender, RoutedEventArgs e)
        {
            Window aboutDeveloper = new Window();

            aboutDeveloper.Height = 400;
            aboutDeveloper.Width = 400;
            aboutDeveloper.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            aboutDeveloper.WindowStyle = WindowStyle.SingleBorderWindow;
            aboutDeveloper.WindowState = WindowState.Normal;
            aboutDeveloper.ResizeMode = ResizeMode.NoResize;

            aboutDeveloper.Title = "Über mich";

            aboutDeveloper.ShowDialog();
        }
        #endregion

        #region ReloadDataGrid
        private void ViewReload_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch.Reset();
            Stopwatch.Start();
            //attendeesList.ItemsSource = null;

            try
            {
                //attendeesList.Items.Clear();
                attendeesList.Items.Refresh();
                //attendeesList.ItemsSource = stringData;
            }
            catch (Exception exViewReload)
            {
                MessageBox.Show(exViewReload.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Stopwatch.Stop();

            StatusBar.Content = "Datenbank aktualisiert in: " + Stopwatch.ElapsedMilliseconds + " ms";
        }
        #endregion

        #region LoadingRow method
        private void attendeesList_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            foreach (var person in stringData)
            {
                int z = 1;
                for (int col = 4; col < attendeesList.Columns.Count; col++)
                {
                    string dayName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, z).ToString("ddd");

                    if (dayName == "Sa" || dayName == "So")
                    {
                        attendeesList.Columns[col].CellStyle = (Style)Resources["Weekend"];
                        z++;
                        continue;
                    }
                    else
                    {
                        if (person.LoginLogoutAttendee.Count == 0)
                        {
                            attendeesList.Columns[col].CellStyle = (Style)Resources["abwesend"];
                            continue;
                        }
                        else
                        {
                            foreach (var personLogin in person.LoginLogoutAttendee)
                            {
                                
                                if (personLogin.Day == z & personLogin.Month == 2)
                                {
                                    if (personLogin.Login != "")
                                    {
                                        //attendeesList.DataContext = personLogin;
                                        attendeesList.Columns[col].CellStyle = (Style)Resources["datagrid"];
                                        var test = attendeesList.Columns[col].GetValue(TextBox.TextProperty);
                                        break;
                                    }
                                }
                                else
                                {
                                    attendeesList.Columns[col].CellStyle = (Style)Resources["abwesend"];
                                }
                            }
                            z++;
                            continue;
                        }
                    }
                }
            }
        }
        #endregion

        private void attendeesList_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
using Microsoft.Data.Sqlite;
using System.Globalization;
using System.Windows;

namespace Zeiterfassung_WPF
{
    /// <summary>
    /// Interaktionslogik für Monatsuebersicht.xaml
    /// </summary>
    public partial class Monatsuebersicht : Window
    {
        GetSqliteQuery getSqliteQuery = new GetSqliteQuery();
        List<DayOfTheWeek> days = new List<DayOfTheWeek>();
        List<Person> personData = new();
        MonthActual monthAct = new MonthActual();
        MonthSummaryHour monthSummaryHour = new MonthSummaryHour();
        //int SummaryMonth = 0;
        public int ColumnCal { get; set; }
        public Monatsuebersicht(SqliteConnection sqlConn, Person person1)
        {
            personData = getSqliteQuery.GetDataPersonFirst(sqlConn, person1);

            //personData = person1;

            foreach (var minutesSummary in personData)
            {
                monthSummaryHour.summaryHours += minutesSummary.SummaryHoursMonth;
            }

            int hours = monthSummaryHour.summaryHours / 60;
            int minutes = monthSummaryHour.summaryHours%60;

            string testSummary = $"{hours}:{minutes}";
            var result = Convert.ToDateTime(testSummary).ToShortTimeString();
            monthSummaryHour.SummaryMonth = result + " Std.";

            InitializeComponent();

            DataContext = this;

            monthAct.MonthName = DateTime.Now.ToString("Y");
            actualMonth.DataContext = monthAct;
            SummaryHourMonth.DataContext = monthSummaryHour;
                                                //icCalendar.ItemTemplate = ;

                                                //TextBlock? textBlk = FindName("MonthNameTest") as TextBlock;

            SetCalendarDays();
        }

        public void SetCalendarDays()
        {
            // TODO to change the year and month dynamically

            monthAct.MonthNow = DateTime.Today.Month;
            monthAct.YearNow = DateTime.Today.Year;

            //monthAct.MonthNow = 9;
            //monthAct.YearNow = 2024;

            for (int i = 1; i <= DateTime.DaysInMonth(monthAct.YearNow, monthAct.MonthNow); i++)
            {

                DateTime date = new DateTime(monthAct.YearNow, monthAct.MonthNow, i);

                // Display the begin of a week, here is monday the first day of week
                #region Begin weekday
                if (i == 1)
                {
                    switch (date.DayOfWeek)
                    {
                        case DayOfWeek.Sunday:
                            ColumnCal = 6;
                            break;
                        case DayOfWeek.Monday:
                            ColumnCal = 0;
                            break;
                        case DayOfWeek.Tuesday:
                            ColumnCal = 1;
                            break;
                        case DayOfWeek.Wednesday:
                            ColumnCal = 2;
                            break;
                        case DayOfWeek.Thursday:
                            ColumnCal = 3;
                            break;
                        case DayOfWeek.Friday:
                            ColumnCal = 4;
                            break;
                        case DayOfWeek.Saturday:
                            ColumnCal = 5;
                            break;
                        default:
                            break;
                    }
                }
                #endregion

                if (date.DayOfWeek.ToString() == "Saturday" || date.DayOfWeek.ToString() == "Sunday")
                {
                    days.Add(
                        new DayOfTheWeek() { DayName = date.ToString("ddd. d"), Background = "White", TextComing = "", TextGoing = "", TextSummary = "Wochenende" });
                }
                else
                {
                    Person? personTest = personData.Find(x => x.Day == date.Day && x.Month == DateTime.Today.Month && x.Year == DateTime.Today.Year);

                    //var personTest = from item in personData
                                         //where item.Day == date.Day && item.Month == date.Month && item.Year == date.Year
                                         //select item;

                    if (personTest == null)
                    {
                        if (date.Day < DateTime.Today.Day)
                        {
                            SetCalendarContent("OrangeRed", date, personTest!);
                        }
                        else if (date.Day > DateTime.Today.Day)
                        {
                            SetCalendarContent("Khaki", date, personTest!);
                        }
                    }
                    else
                    {
                        if (personTest!.Day == date.Day & personTest!.Month == date.Month & personTest!.Year == date.Year)
                        {
                            if (personTest.LoginTime != null)
                            {
                                SetCalendarContent("SpringGreen", date, personTest);
                            }
                            else
                            {
                                SetCalendarContent("Khaki", date, personTest);
                            }
                        }
                        else
                        {    
                            if (date.Day < DateTime.Today.Day)
                            {
                                SetCalendarContent("OrangeRed", date, personTest!);
                            }
                            else if (date.Day > DateTime.Today.Day)
                            {
                                SetCalendarContent("Khaki", date, personTest!);
                            }
                        }
                    }
                }
            }
            icCalendar.ItemsSource = days;
        }

        internal void SetCalendarContent(string color, DateTime date, Person personTest)
        {
            string colorBackground = "";

            if (color == "Khaki") colorBackground = color;
            if (color == "SpringGreen") colorBackground = color;
            if (color == "OrangeRed") colorBackground = color;

            if (personTest != null)
            {
                days.Add(new DayOfTheWeek()
                {
                    DayName = date.ToString("ddd. d"),
                    Background = colorBackground,
                    TextComing = personTest.LoginTime,
                    TextGoing = personTest.LogoutTime,
                    TextSummary = personTest.diffTime
                });
            }
            else
            {
                days.Add(new DayOfTheWeek()
                {
                    DayName = date.ToString("ddd. d"),
                    Background = colorBackground,
                    TextComing = "",
                    TextGoing = "",
                    TextSummary = ""
                });
            }
        }
    }
    public class DayOfTheWeek
    {
        public string? DayName { get; set; }
        public string? Background { get; set; }
        public string? TextComing { get; set; }
        public string? TextGoing { get; set; }
        public string? TextSummary { get; set; }
    }
    public class MonthActual
    {
        public int MonthNow { get; set; }
        public int YearNow { get; set; }
        public string? MonthName { get; set; }
    }
    public class MonthSummaryHour
    {
        public int summaryHours { get; set; }
        public string SummaryMonth { get; set; }
    }
}


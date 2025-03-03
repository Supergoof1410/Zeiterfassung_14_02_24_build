using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using Zeiterfassung_Anleiter_WPF.Person;

namespace Zeiterfassung_Anleiter_WPF.Database.ReaderWriter
{
    internal class GetSqliteQuery
    {
        internal SqliteCommand? command;
        AttendeeNumbersDB attendeeNumbers = new();
        Attendee? attendee { get; set; }
        ObservableCollection<Attendee> attendeeList = new();
        //LoginLogout logging = new();

        /// <summary>
        /// Get the attendee numbers only
        /// </summary>
        /// <param name="SqliteConn">Reference of the connection</param>
        /// <param name="attendeeNumberList">Reference of the a generic list</param>
        /// <param name="isNull"></param>
        /// <returns>Generic List from type AttendeeNumbersDB</returns>
        #region GetAttendeeNumbers
        internal ObservableCollection<AttendeeNumbersDB> GetAttendeeNumbers(SqliteConnection SqliteConn, ObservableCollection<AttendeeNumbersDB> attendeeNumberList, bool isNull)
        {

            string ifNull = (isNull == true) ? "IS NULL" : "IS NOT NULL";

            try
            {
                command = SqliteConn.CreateCommand();
                command.CommandText = $"SELECT attendee_id, attendee_number, fk_persons FROM attendee WHERE fk_persons {ifNull};";

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        attendeeNumbers.AttendeeID = reader.GetInt32(0);
                        attendeeNumbers.AttendeeNumber = reader.GetString(1);
                        attendeeNumbers.FkPersonsID = !reader.IsDBNull(reader.GetOrdinal("fk_persons")) ? reader.GetInt32(2) : null;
                        attendeeNumberList.Add(attendeeNumbers);
                        attendeeNumbers = new AttendeeNumbersDB();
                    }
                }
                return attendeeNumberList;
            }
            catch (Exception GetException)
            {
                MessageBox.Show(GetException.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return attendeeNumberList;
            }
        }
        #endregion

        #region Get data from Attendee with logging time
        internal ObservableCollection<Attendee> GetDataPersons(SqliteConnection? connection)
        {
            try
            {
                command = connection!.CreateCommand();
                command.CommandText = $"" +
                    $"SELECT persons_id, lastname, firstname, passwd FROM persons;";
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //attendeeList.Clear();
                        attendee = new Attendee();
                        attendee.AttendeeID = (int)reader.GetInt32(0);
                        attendee.Lastname = reader.GetString(1);
                        attendee.Firstname = reader.GetString(2);
                        attendee.Password = reader.GetString(3);

                        for (int days = 1; days < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); days++)
                        {
                            LoginLogout log = new();
                            log.Year = DateTime.Now.Year;
                            log.Month = DateTime.Now.Month;
                            log.Day = days;
                            log.Persons_id = attendee.AttendeeID;
                            attendee.LoginLogoutAttendee.Add(log);
                        }

                        attendee.LoginLogoutAttendee = GetLoggingTime(connection, attendee);
                        attendeeList.Add(attendee);
                    }
                }
                return attendeeList;
            }
            catch (Exception exGetDataPerson)
            {
                MessageBox.Show(exGetDataPerson.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return attendeeList;
            }
        }

        internal ObservableCollection<LoginLogout> GetLoggingTime(SqliteConnection? connection, Attendee attendee)
        {
            try
            {
                command = connection!.CreateCommand();
                command.CommandText = $"" +
                    $"SELECT fk_persons_id, fk_login_time, fk_logout_time, day, month, fk_year, fk_diffTime, " +
                    $"(SELECT loggingTime.logDayTime FROM loggingTime WHERE loggingTime.loggingTime_id = login_logout.fk_login_time) AS Login, " +
                    $"(SELECT loggingTime.logDayTime FROM loggingTime WHERE loggingTime.loggingTime_id = login_logout.fk_logout_time) AS Logout, " +
                    $"(SELECT diffTime.timeSpan FROM diffTime WHERE diffTime_id = login_logout.fk_diffTime) AS DayHours, " +
                    $"(SELECT logYear.year FROM logYear WHERE logYear.logYear_id = login_logout.fk_year) AS Year " +
                    $"FROM login_logout " +
                    $"WHERE fk_persons_id = '{attendee.AttendeeID}';";
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int dayFromReader = reader.GetInt32(3);

                        foreach (var day in attendee.LoginLogoutAttendee)
                        {
                            //int z = 3;
                            if(day.Day == dayFromReader)
                            {
                                
                            }

                            //if (day.Day == reader[z])
                            //{
                            //    logging.Persons_id = (int)reader.GetInt32(0);
                            //    logging.Login = reader.GetString(7);
                            //    logging.Logout = reader.GetString(8);
                            //    logging.Day = reader.GetInt32(3);
                            //    logging.Month = reader.GetInt32(4);
                            //    logging.Year = reader.GetInt32(5);
                            //    logging.TimeSpan = reader.GetString(6);
                            //}
                        }
                        //continue;
                        //loginLogouts.Add(logging);
                        //attendee.LoginLogoutAttendee.Add(logging);
                        //logging = new LoginLogout();
                    }
                }

            }
            catch (Exception exGetLoggingTime)
            {
                MessageBox.Show(exGetLoggingTime.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return attendee.LoginLogoutAttendee;
            }
            return attendee.LoginLogoutAttendee;
        }
        #endregion
    }
}

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Zeiterfassung_WPF
{
    internal class GetSqliteQuery
    {
        internal SqliteCommand? command;

        List<AttendeeList> listAttendee = new List<AttendeeList>();
        AttendeeList attendeeList = new();
        List<Person> personList = new();
        int resultMinutes = 0;


        // Gets the attendee list for the login window
        #region Attendeelist for first start
        internal List<AttendeeList> GetAttendee(SqliteConnection SqliteConn)
        {
            try
            {
                command = SqliteConn!.CreateCommand();
                command.CommandText = @"SELECT attendee_id, attendee_number FROM attendee WHERE fk_persons IS NOT NULL;";

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        attendeeList.Attendee_ID = reader.GetInt32(0);
                        attendeeList.Attendee_Number = reader.GetString(1);
                        listAttendee.Add(attendeeList);
                        attendeeList = new AttendeeList();
                    }
                }
                return listAttendee;
            }
            catch (Exception exListAttendee)
            {
                WriteFile.WriteFiles(2, exListAttendee.Message);
                return null!;
            }
        }
        #endregion

        #region Password check
        internal bool CheckPassword(SqliteConnection SqliteConn, string passwd, string attendee_number)
        {
            try
            {
                command = SqliteConn.CreateCommand();
                command.CommandText = $"SELECT persons.passwd FROM attendee " +
                    $"JOIN persons ON persons.persons_id = attendee.fk_persons " +
                    $"WHERE attendee.attendee_number = '{attendee_number}';";
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var passSql = reader.GetString(0);
                        if (passwd == passSql) return true;
                    }
                }
            }
            catch (Exception exCheckPassword)
            {
                WriteFile.WriteFiles(2, exCheckPassword.Message);
                WriteFile.WriteFiles(2, "Falsches Passwort!");
            }
            return false;
        }
        #endregion

        internal List<Person> GetDataPersonFirst(SqliteConnection SqliteConn, Person person)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                command = SqliteConn.CreateCommand();
                command.CommandText = $"SELECT persons.persons_id, attendee.attendee_number, persons.firstname, persons.lastname, persons.SummaryMonthHours, login_logout.day, login_logout.month, " +
                    $"(SELECT loggingTime.logDayTime FROM loggingTime WHERE loggingTime.loggingTime_id = login_logout.fk_login_time) AS Login, " +
                    $"(SELECT loggingTime.logDayTime FROM loggingTime WHERE loggingTime.loggingTime_id = login_logout.fk_logout_time) AS Logout, " +
                    $"(SELECT diffTime.timeSpan FROM diffTime WHERE diffTime_id = login_logout.fk_diffTime) AS DayHours, " +
                    $"(SELECT logYear.year FROM logYear WHERE logYear.logYear_id = login_logout.fk_year) AS Year " +
                    $"FROM login_logout, attendee " +
                    $"JOIN persons ON login_logout.fk_persons_id = persons.persons_id " +
                    $"WHERE attendee.attendee_number = '{person.Tn_Value}' " +
                    $"AND persons.persons_id = attendee.fk_persons " + 
                    $"AND YEAR = {DateTime.Now.Year} " +
                    $"AND login_logout.month = {DateTime.Now.Month};";
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        person = new Person();
                        person.Person_ID = reader.GetInt32(0);
                        person.Tn_Value = reader.GetString(1);
                        person.Firstname = reader.GetString(2);
                        person.Lastname = reader.GetString(3);
                        person.SummaryHoursMonth = reader.GetInt32(4);
                        person.Day = reader.GetInt32(5);
                        person.Month = reader.GetInt32(6);
                        
                        // This is necessary, because the return value can be null
                        person.LoginTime = !reader.IsDBNull(reader.GetOrdinal("Login")) ? reader.GetString(7) : null;
                        person.LogoutTime = !reader.IsDBNull(reader.GetOrdinal("Logout")) ? reader.GetString(8) : null;
                        person.diffTime = !reader.IsDBNull(reader.GetOrdinal("DayHours")) ? reader.GetString(9) : null;
                        person.Year = reader.GetInt32(10);
                        
                        DateTime minutes = Convert.ToDateTime(person.diffTime);
                        resultMinutes = minutes.Minute + (minutes.Hour * 60);
                        
                        person.SummaryHoursMonth = resultMinutes;

                        personList.Add(person);
                    }
                    
                }
                stopwatch.Stop();
                WriteFile.WriteFiles(0, $"[{Environment.UserName}] Einträge eingelesen ({stopwatch.ElapsedMilliseconds} ms)");
            }
            catch (Exception exGetDataPersonFirst)
            {
                WriteFile.WriteFiles(2, exGetDataPersonFirst.Message);
                WriteFile.WriteFiles(2, "Keine Daten gefunden!");
            }
            return personList;
        }
    }
}

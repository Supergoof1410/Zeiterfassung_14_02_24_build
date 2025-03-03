using Microsoft.Data.Sqlite;
using System;
using System.Diagnostics;

namespace Zeiterfassung_WPF
{
    internal class SetSqliteQuery
    {
        internal SqliteCommand? command;
        private Stopwatch _stopwatch = new Stopwatch();

        #region Set attendee into login_logout
        internal void SetAttendeeFirstStart(SqliteConnection connSql, Person personData)
        {
            // TODO
            try
            {
                _stopwatch.Start();
                command = connSql.CreateCommand();
                command.CommandText = $"" +
                    $"INSERT INTO login_logout " +
                    $"(fk_persons_id, day, month, fk_year) " +
                    $"VALUES " +
                    $"((SELECT persons_id " +
                    $"FROM persons JOIN attendee ON persons.persons_id = attendee.fk_persons WHERE attendee.attendee_number = '{personData.Tn_Value}'), " +
                    $"{personData.Day}, {personData.Month}, " +
                    $"(SELECT logYear_id FROM logYear WHERE year = {personData.Year}));";
                command.ExecuteNonQueryAsync();
                _stopwatch.Stop();
                WriteFile.WriteFiles(0, $"[{Environment.UserName}] Erster Eintrag geschrieben ({_stopwatch.ElapsedMilliseconds} ms)");
            }
            catch (Exception exSetAttendeeLogin)
            {
                WriteFile.WriteFiles(2, exSetAttendeeLogin.Message);
                WriteFile.WriteFiles(2, "Insert fehlgeschlagen");
            }
        }
        #endregion

        #region Sets Login/Logout
        internal void SetPersonLoginLogout(SqliteConnection connSql, Person personData, int logMode)
        {
            int loginlogout = logMode;
            
            string? fk_login = "";
            string? logTime = "";

            switch (loginlogout)
            {
                case 1:
                    {
                        fk_login = "fk_login_time";
                        logTime = personData.LoginTime;
                        break;
                    }
                case 2:
                    {
                        fk_login = "fk_logout_time";
                        logTime = personData.LogoutTime;
                        break;
                    }
                default: break;
            }

            try
            {
                _stopwatch.Start();
                command = connSql.CreateCommand();
                command.CommandText = $"" +
                    $"UPDATE login_logout " +
                    $"SET {fk_login} = " +
                    $"(SELECT loggingTime_id FROM loggingTime WHERE logDayTime = '{logTime}') " +
                    $"WHERE day = {personData.Day} AND month = {personData.Month} " +
                    $"AND fk_year = " +
                    $"(SELECT logYear_id FROM logYear WHERE year = {personData.Year}) " +
                    $"AND fk_persons_id = " +
                    $"(SELECT persons_id FROM persons JOIN attendee ON persons.persons_id = attendee.fk_persons WHERE attendee.attendee_number = '{personData.Tn_Value}');";
                command.ExecuteNonQueryAsync();
                _stopwatch.Stop();
                WriteFile.WriteFiles(0, $"[{Environment.UserName}] Eintrag aktualisiert (Kommen/Gehen) ({_stopwatch.ElapsedMilliseconds} ms)");
            }
            catch (Exception exSetPersonLogin)
            {
                WriteFile.WriteFiles(2, exSetPersonLogin.Message);
                WriteFile.WriteFiles(2, "Login fehlgeschlagen");
            }
        }
        #endregion

        #region Update the time difference
        internal void UpdateAttendeeTimeSpan(SqliteConnection connSql, Person personData)
        {
            try
            {
                _stopwatch.Start();
                var command = connSql.CreateCommand();
                command.CommandText = $"" +
                    $"UPDATE login_logout " +
                    $"SET fk_diffTime = " +
                    $"(SELECT diffTime_id FROM diffTime WHERE timeSpan = '{personData.diffTime}') " +
                    $"WHERE day = {personData.Day} AND month = {personData.Month} " +
                    $"AND fk_year = (SELECT logYear_id FROM logYear WHERE year = {personData.Year}) " +
                    $"AND fk_persons_id = " +
                    $"(SELECT persons_id FROM persons JOIN attendee ON persons.persons_id = attendee.fk_persons " +
                    $"AND attendee.attendee_number = '{personData.Tn_Value}'); ";
                    //$"UPDATE persons SET ;";
                command.ExecuteNonQueryAsync();
                _stopwatch.Stop();
                WriteFile.WriteFiles(0, $"[{Environment.UserName}] Eintrag aktualisiert (Zeitdifferenz) ({_stopwatch.ElapsedMilliseconds} ms)");
            }
            catch (Exception exUpdateTimeSpan)
            {
                WriteFile.WriteFiles(2, exUpdateTimeSpan.Message);
                WriteFile.WriteFiles(2, "Update fehlgeschlagen");
            }
        }
        internal void UpdateAttendeeMonthHours(SqliteConnection connSql, Person personData)
        {
            try
            {
                _stopwatch.Start();
                var command = connSql.CreateCommand();
                command.CommandText = $"" +
                    $"UPDATE persons " +
                    $"SET SummaryMonthHours = {personData.SummaryHoursMonth} " +
                    $"WHERE persons_id = " +
                    $"(SELECT fk_persons_id FROM login_logout " +
                    $"JOIN attendee ON persons.persons_id = attendee.fk_persons " +
                    $"JOIN persons ON persons.persons_id = login_logout.fk_persons_id " +
                    $"AND attendee.attendee_number = '{personData.Tn_Value}'); ";
                //$"UPDATE persons SET ;";
                command.ExecuteNonQueryAsync();
                _stopwatch.Stop();
                WriteFile.WriteFiles(0, $"[{Environment.UserName}] Eintrag aktualisiert (Zeitdifferenz) ({_stopwatch.ElapsedMilliseconds} ms)");
            }
            catch (Exception exUpdateTimeSpan)
            {
                WriteFile.WriteFiles(2, exUpdateTimeSpan.Message);
                WriteFile.WriteFiles(2, "Update fehlgeschlagen");
            }
        }
        #endregion
    }
}

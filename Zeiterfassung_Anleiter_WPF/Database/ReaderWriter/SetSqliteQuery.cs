using Microsoft.Data.Sqlite;
using System.Windows;
using Zeiterfassung_Anleiter_WPF.Person;

namespace Zeiterfassung_Anleiter_WPF.Database.ReaderWriter
{
    internal class SetSqliteQuery
    {
        internal SqliteCommand? command;
        internal bool InsertPerson(SqliteConnection connSqlite, Attendee attendee)
        {
            try
            {
                command = connSqlite.CreateCommand();
                command.CommandText = $"" +
                    $"INSERT INTO persons " +
                    $"(persons_id, firstname, lastname, passwd, BeginMeasure, EndMeasure, condition, BeginWork, EndWork, SummaryHoursDay, SummaryWeekdays) " +
                    $"VALUES (" +
                    $"'{attendee.AttendeeID}', '{attendee.Firstname}', '{attendee.Lastname}', '{attendee.Password}', '{attendee.BeginMeasure}', '{attendee.EndMeasure}', " +
                    $"'{attendee.Condition}', '{attendee.BeginWork.ToShortTimeString()}', '{attendee.EndWork.ToShortTimeString()}', " +
                    $"'{attendee.SummaryHoursDay.ToShortTimeString()}', {attendee.SummaryWorkDays} " +
                    $");" +
                    $"" +
                    $"UPDATE attendee SET (fk_persons) = {attendee.AttendeeID} WHERE attendee_id = '{attendee.AttendeeID}';";
                command.ExecuteNonQuery();
            }
            catch (Exception InsertEx)
            {
                MessageBox.Show(InsertEx.Message, "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}

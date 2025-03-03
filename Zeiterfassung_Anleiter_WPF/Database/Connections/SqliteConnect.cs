using Microsoft.Data.Sqlite;
using System.IO;
using System.Windows;
using System.Diagnostics;
using System.Configuration;

namespace Zeiterfassung_Anleiter_WPF.Database.Connections
{


    static internal class SqliteConnect
    {
        internal static SqliteCommand? command;
        internal static SqliteConnection? conn;

        internal static string date = DateTime.Now.ToString("MMMM_yyyy");

        internal static string pathAnleiter = ConfigurationManager.ConnectionStrings["pathAnleiterDB"].ConnectionString;
        internal static string dbFileAnleiter = ConfigurationManager.ConnectionStrings["DBFileAnleiter"].ConnectionString;

        internal static string pathTeilnehmerDB = ConfigurationManager.ConnectionStrings["pathTeilnehmerDB"].ConnectionString;
        internal static string dbFileTeilnehmer = ConfigurationManager.ConnectionStrings["DBFileTeilnehmer"].ConnectionString;

        internal static SqliteConnection? ConnectSqlite(int WhichDatabase)
        {
            SqliteConnectionStringBuilder connection = new()
            {
                DefaultTimeout = 2000,
            };

            if (WhichDatabase == 0)
            {
                connection.DataSource = pathAnleiter + date + dbFileAnleiter;
            }
            else
            {
                connection.DataSource = pathTeilnehmerDB + date + dbFileTeilnehmer;
                connection.Password = "affengehirn";
            }

            // DB doesnt exists create a new one with the actual month and create tables 
            if (!File.Exists(connection.DataSource))
            {
                try
                {
                    connection.Mode = SqliteOpenMode.ReadWriteCreate;
                    conn = new SqliteConnection(connection.ConnectionString);
                    conn.Open();

                    command = conn.CreateCommand();
                    command.CommandText = File.ReadAllText(@"C:\Zeiterfassung_DB\Anleiter\create_tables_for_program.sql");
                    command.ExecuteNonQuery();

                    if (WhichDatabase == 1)
                    {
                        command = conn.CreateCommand();
                        command.CommandText = "SELECT quote($newPassword);";
                        command.Parameters.AddWithValue("$newPassword", "affengehirn");
                        var quotedNewPassword = command.ExecuteScalar() as string;

                        command.CommandText = "PRAGMA rekey = " + quotedNewPassword;
                        command.Parameters.Clear();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception SqliteConnectionEx)
                {
                    MessageBox.Show(SqliteConnectionEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            else
            {
                try
                {
                    connection.Mode = SqliteOpenMode.ReadWrite;
                    
                    if (WhichDatabase == 1)
                    {
                        connection.Password = "affengehirn";
                    }
                    
                    conn = new SqliteConnection(connection.ConnectionString);
                    conn.Open();
                }
                catch (Exception SqliteConnectionEx)
                {
                    MessageBox.Show(SqliteConnectionEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            return conn;
        }
    }
}

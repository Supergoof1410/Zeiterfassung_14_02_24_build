using Microsoft.Data.Sqlite;
using System;
using System.Diagnostics;

namespace Zeiterfassung_WPF
{
    static internal class ConnectSqlite
    {
        static internal SqliteConnection? conn;

        static internal SqliteConnection? ConnectToSqlite(string source)
        {
            SqliteConnectionStringBuilder connection = new SqliteConnectionStringBuilder
            {
                DataSource = source,
                Mode = SqliteOpenMode.ReadWriteCreate,
                DefaultTimeout = 2000,
                Password = "affengehirn"
            };
            
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                conn = new SqliteConnection(connection.ToString());
                conn.Open();
                watch.Stop();
                WriteFile.WriteFiles(0, $"[{Environment.UserName}] Datenbank erfolgreich geöffnet");
                WriteFile.WriteFiles(0, $"[{Environment.UserName}] Datenbank erfolgreich entschlüsselt ({watch.ElapsedMilliseconds} ms)");
            }
            catch (Exception exSqlite)
            {
                WriteFile.WriteFiles(2, exSqlite.Message);
                return null;
            }
            //finally
            //{
            //    conn!.Close();
            //}
            return conn;
        }
    }
}

using System;
using System.IO;

namespace Zeiterfassung_WPF
{
    internal static class WriteFile
    {
        // TODO
        internal static void WriteFiles(int code, string message)
        {
            StreamWriter? writer;

            string databaseDirectoryFile = @".\SqliteDB\";
            string pathDir = @".\Log\";
            string fileNormal = @"log.txt";
            string fileError = @"error.txt";

            string? date = $"[{DateTime.Now}] - ";

            // if directorys doesnt exists
            if (!Directory.Exists(pathDir)) Directory.CreateDirectory(pathDir);
            if (!Directory.Exists(databaseDirectoryFile)) Directory.CreateDirectory(databaseDirectoryFile);

            switch (code)
            {
                case 0:
                    CreateFiles(pathDir + fileNormal);
                    writer = new StreamWriter(pathDir + fileNormal, append: true);
                    WriteLogFile.WriteLog(writer, date + message);
                    break;
                case 1:
                    CreateFiles(pathDir + fileError);
                    writer = new StreamWriter(pathDir + fileError, append: true);
                    WriteLogFile.WriteLog(writer, date + "[Error] - " + message);
                    break;
                case 2:
                    CreateFiles(pathDir + fileError);
                    writer = new StreamWriter(pathDir + fileError, append: true);
                    WriteLogFile.WriteLog(writer, date + "[Sqlite-Error] - " + message);
                    break;
                default:
                    break;
            }
        }
        private static void CreateFiles(string fileName)
        {
            // if file doesnt exists
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }
    }
}

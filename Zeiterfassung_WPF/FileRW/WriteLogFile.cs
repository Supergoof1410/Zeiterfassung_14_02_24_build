using System.IO;

namespace Zeiterfassung_WPF
{
    internal static class WriteLogFile
    {
        // Todo
        internal static void WriteLog(StreamWriter pathWriter, string logMessage)
        {
            StreamWriter? logWriter = pathWriter;

            logWriter.WriteLine(logMessage);
            logWriter.Close();
        }
    }
}

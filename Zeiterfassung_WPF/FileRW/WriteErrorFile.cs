using System.IO;

namespace Zeiterfassung_WPF
{
    internal class WriteErrorFile
    {
        // Todo
        internal static void WriteErrorLog(StreamWriter pathWriter, string path, string logMessage)
        {
            StreamWriter? logWriter = pathWriter;

            File.SetAttributes(path, FileAttributes.Normal);

            logWriter.WriteLine(logMessage);
            logWriter.Close();

            File.SetAttributes(path, FileAttributes.Hidden);
        }
    }
}

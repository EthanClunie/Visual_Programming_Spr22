using System.IO;

public static class Logger
{
    private static StreamWriter writer;
    public static void Create(bool isAppending)
    {
        CreateLogFile(isAppending);
        WriteHeader();
    }

    public static void Log(string message)
    {
        writer.WriteLine(message);
    }

    private static void WriteHeader()
    {
        writer.WriteLine("///// New Run: " + System.DateTime.Now + " /////");
    }

    private static void CreateLogFile(bool isAppending)
    {
        // make a new log file
        writer = new StreamWriter("Assets/Logs/logFile.txt", isAppending);
        writer.AutoFlush = true;
    }
}

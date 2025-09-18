using System.Collections;

class SimpleDemo : ILogger
{
    public void Log(string log)
    {
        Console.WriteLine(log);
    }
}

interface ILogger
{
    void Log(string log);
}

class Logger(string date, int id) : ILogger
{
    string Date => date;
    int Id => id;

    public void Log(string log)
    {
        Console.WriteLine($"Recorded a log.{Date}, {Id}, {log}");
    }
}
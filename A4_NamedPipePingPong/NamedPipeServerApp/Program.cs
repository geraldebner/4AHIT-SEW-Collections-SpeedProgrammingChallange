using System;

namespace NamedPipeServerApp;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Named Pipe Server ===");
        Console.WriteLine("1. Start Server");
        Console.WriteLine("2. Exit");
        var choice = Console.ReadLine();
        if (choice == "1")
        {
            var server = new NamedPipeServer();
            server.StartServer();
        }
    }
}

class NamedPipeServer
{
    public void StartServer()
    {
        Console.WriteLine("Server started. Waiting for client...");
        // TODO: Implement Named Pipe server logic here
    }
}

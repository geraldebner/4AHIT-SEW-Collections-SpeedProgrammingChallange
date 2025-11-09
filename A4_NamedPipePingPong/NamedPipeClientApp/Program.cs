using System;

namespace NamedPipeClientApp;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Named Pipe Client ===");
        Console.WriteLine("1. Start Client");
        Console.WriteLine("2. Exit");
        var choice = Console.ReadLine();
        if (choice == "1")
        {
            var client = new NamedPipeClient();
            client.StartClient();
        }
    }
}

class NamedPipeClient
{
    public void StartClient()
    {
        Console.WriteLine("Client started. Connecting to server...");
        // TODO: Implement Named Pipe client logic here
    }
}

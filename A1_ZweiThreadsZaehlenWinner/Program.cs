using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{
    private static readonly object lockObject = new object();
    private static int currentNumberA = 0;
    private static int currentNumberB = 0;
    private static bool meetingPointReached = false;
    private static string? winner = null;
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 1: Zwei Threads – Zählen & Winner");
        
        Thread threadA = new Thread(CountUpThreadA);
        Thread threadB = new Thread(CountDownThreadB);
        
        threadA.Start();
        threadB.Start();
        
        threadA.Join();
        threadB.Join();
        
        Console.WriteLine("\nBeide Threads beendet.");
    }
    
    private static void CountUpThreadA()
    {
        for (int i = 1; i <= 100; i++)
        {
            lock (lockObject)
            {
                if (meetingPointReached)
                    break;
                    
                currentNumberA = i;
                Console.WriteLine($"Thread A: {i}");
                
                // Prüfen ob beide Threads die gleiche Zahl erreicht haben
                if (currentNumberA == currentNumberB && currentNumberB > 0)
                {
                    meetingPointReached = true;
                    Console.WriteLine("\n*** DONE ***");
                    
                    // Thread A ist schneller wenn er die höhere Zahl erreicht hat
                    if (winner == null)
                    {
                        winner = "A";
                        Console.WriteLine("*** WINNER: Thread A ***\n");
                    }
                    break;
                }
            }
            
            Thread.Sleep(100);
        }
    }
    
    private static void CountDownThreadB()
    {
        for (int i = 100; i >= 1; i--)
        {
            lock (lockObject)
            {
                if (meetingPointReached)
                    break;
                    
                currentNumberB = i;
                Console.WriteLine($"Thread B: {i}");
                
                // Prüfen ob beide Threads die gleiche Zahl erreicht haben
                if (currentNumberA == currentNumberB && currentNumberA > 0)
                {
                    meetingPointReached = true;
                    Console.WriteLine("\n*** DONE ***");
                    
                    // Thread B ist schneller wenn er die niedrigere Zahl erreicht hat
                    if (winner == null)
                    {
                        winner = "B";
                        Console.WriteLine("*** WINNER: Thread B ***\n");
                    }
                    break;
                }
            }
            
            Thread.Sleep(100);
        }
    }
}

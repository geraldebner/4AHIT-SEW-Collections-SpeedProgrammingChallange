using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace A3_ProducerConsumerQueue;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 3: Producer-Consumer");
        Console.WriteLine("==========================================\n");

        // ConcurrentQueue erstellen
        ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

        // 5 Producer erstellen
        Producer[] producers = new Producer[5];
        for (int i = 0; i < 5; i++)
        {
            producers[i] = new Producer(queue, i + 1);
        }

        // 1 Consumer erstellen
        Consumer consumer = new Consumer(queue);

        Console.WriteLine("Producer und Consumer gestartet...\n");

        // Überwachung: Jede Sekunde Queue-Füllstand ausgeben und auf >50 prüfen
        while (true)
        {
            Thread.Sleep(1000); // 1 Sekunde warten

            int queueSize = queue.Count;
            Console.WriteLine($"\n>>> Queue-Füllstand: {queueSize} Einträge <<<\n");

            // Programm beenden wenn Queue mehr als 50 Einträge hat
            if (queueSize > 50)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("Queue hat mehr als 50 Einträge erreicht!");
                Console.WriteLine("Beende Programm...");
                Console.WriteLine("==========================================\n");
                break;
            }
        }

        // Alle Producer stoppen
        foreach (Producer producer in producers)
        {
            producer.Stop();
        }

        // Consumer stoppen
        consumer.Stop();

        // Endstatistik
        Console.WriteLine($"\nEndsumme vom Consumer: {consumer.GetSum()}");
        Console.WriteLine($"Finale Queue-Größe: {queue.Count}");
        Console.WriteLine("\nProgramm beendet.");
    }
}

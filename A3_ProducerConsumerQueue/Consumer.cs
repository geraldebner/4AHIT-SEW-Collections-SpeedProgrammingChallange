using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace A3_ProducerConsumerQueue;

public class Consumer
{
    private readonly ConcurrentQueue<int> queue;
    private Thread? consumerThread;
    private volatile bool shouldStop = false;
    private int sum = 0;

    public Consumer(ConcurrentQueue<int> queue)
    {
        this.queue = queue;
        
        // Thread im Konstruktor starten
        consumerThread = new Thread(ConsumeNumbers);
        consumerThread.Start();
    }

    private void ConsumeNumbers()
    {
        while (!shouldStop)
        {
            if (queue.TryDequeue(out int number))
            {
                sum += number;
                Console.WriteLine($"[Consumer] Konsumiert: {number} | Aktuelle Summe: {sum} | Queue-Größe: {queue.Count}");
            }
            
            Thread.Sleep(250); // 250ms Takt
        }
    }

    public void Stop()
    {
        shouldStop = true;
        consumerThread?.Join();
    }

    public int GetSum()
    {
        return sum;
    }
}

using System.Collections.Concurrent;

namespace ex_2;

public class Server
{
    private static int _count = 0;
    private static readonly ReaderWriterLockSlim Lock = new();
    private static readonly BlockingCollection<Action> WriteQueue = new();
    private static readonly ManualResetEventSlim WriteCompleted = new(true);
    private static int _pendingWrites = 0;

    static Server()
    {
        // Запускаем отдельный поток для обработки очереди записи
        new Thread(() =>
        {
            foreach (var action in WriteQueue.GetConsumingEnumerable())
            {
                Interlocked.Increment(ref _pendingWrites);
                WriteCompleted.Reset();
                try
                {
                    Lock.EnterWriteLock();
                    try
                    {
                        action();
                    }
                    finally
                    {
                        Lock.ExitWriteLock();
                    }
                }
                finally
                {
                    if (Interlocked.Decrement(ref _pendingWrites) == 0)
                    {
                        WriteCompleted.Set();
                    }
                }
                
                
                
            }
        }) { IsBackground = true }.Start();
    }


    public static int GetCount()
    {
        WriteCompleted.Wait();
        
        Lock.EnterReadLock();
        try
        {
            return _count;
        }
        finally
        {
            Lock.ExitReadLock();
        }
    }

    public static void AddCount(int i)
    {
        WriteQueue.Add(() =>
        {
            _count += i;
            Console.WriteLine("Успешно");
            
        });
    }
    
    public static void WaitForWritesComplete()
    {
        WriteCompleted.Wait();
    }
    
}
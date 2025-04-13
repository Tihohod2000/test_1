namespace ex_2;

public class server
{
    private static int _count = 0;
    private static readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();


    public static int GetCount()
    {
        _lock.EnterReadLock();
        try
        {
            return _count;
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    public static void AddCount(int i)
    {
        _lock.EnterWriteLock();
        try
        {
            _count += i;

        }
        finally
        {
            _lock.ExitWriteLock();
        }
  
    }
}
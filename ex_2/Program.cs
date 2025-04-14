using ex_2;
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine(Server.GetCount());
        Server.AddCount(15);
        // Thread.Sleep(500);
        Console.WriteLine(Server.GetCount());
        // Thread.Sleep(500);
        Server.AddCount(10);
        // Thread.Sleep(500);


        Console.WriteLine(Server.GetCount());
        
        
        Server.WaitForWritesComplete();
        Console.WriteLine("Записи завершены. Для окончания работы нажмите Enter");
        Console.ReadLine();
    }
}
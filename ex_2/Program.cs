using ex_2;
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Server.AddCount(15);
        Thread.Sleep(5000);
        Server.AddCount(10);
        
        
        Console.WriteLine(Server.GetCount());
        
        
        Server.WaitForWritesComplete();
        Console.WriteLine("All writes completed");
    }
}
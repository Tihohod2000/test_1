using ex_2;
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine(Server.GetCount());
        Server.AddCount(15);
        Console.WriteLine(Server.GetCount());
        Thread.Sleep(3000);
        Server.AddCount(10);
        Thread.Sleep(3000);


        Console.WriteLine(Server.GetCount());
        
        
        Server.WaitForWritesComplete();
        Console.WriteLine("All writes completed");
    }
}
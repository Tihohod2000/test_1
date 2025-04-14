using test_1;

compressor comm = new compressor();


Console.WriteLine("Выберите действие:");
Console.WriteLine("1. Сжатие строки");
Console.WriteLine("2. Декомпрессия строки");
string ch = Console.ReadLine();

if (ch == "1")
{
    Console.WriteLine("Введите строку");
    var line = Console.ReadLine();
    string st = comm.compression(line);
    Console.WriteLine($"компрессия строки: {line}");
    Console.WriteLine($"Результат: {st}");
    
}
else if (ch == "2")
{
    Console.WriteLine("Введите строку");
    var line = Console.ReadLine();
    string st = comm.decompression(line);
    Console.WriteLine($"Декомпрессия строки: {line}");
    Console.WriteLine($"Результат: {st}");
}
else
{
    Console.WriteLine("Error");
}

Console.WriteLine("Для окончания работы нажмите Enter");
Console.ReadLine();

// string short_st = comm.compression("aaabbcccdde");
// string full_st = comm.decompression("a3b2c3d2e");
// Console.WriteLine($"компрессия строки: {short_st}");
// Console.WriteLine($"декомпрессия строки: {full_st}");

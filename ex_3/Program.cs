using ex_3;

string[] lines = File.ReadAllLines("../../../file.txt");
string filePath = "problems.txt";

foreach (string line in lines)
{
    
    InfoObj entry = null;
    if (TryParseLogLine(line, out entry) || TryParseStructuredLog(line, out entry))
    {
        Console.WriteLine(entry.ToString());
    }
    else
    {
        Console.WriteLine("Ошибка структуры лога!!! \nЛог записан в файл problems.txt");
        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            writer.WriteLine(line);
        }
    }
}

Console.WriteLine("Все логи обработаны. Для окончания работы нажмите Enter");
Console.ReadLine();


bool TryParseLogLine(string line, out InfoObj entry)
{
    try
    {
        entry = InfoObj.ParseFromLogLine(line);
        return true;
    }
    catch (Exception ex)
    {
        entry = null;
        return false;
    }
}

bool TryParseStructuredLog(string line, out InfoObj entry)
{
    try
    {
        entry = InfoObj.ParseFromStructuredLog(line);
        return true;
    }
    catch (Exception ex)
    {
        entry = null;
        return false;
    }
}
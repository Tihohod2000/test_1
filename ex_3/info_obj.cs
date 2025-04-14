using System.Globalization;
using System.Text.RegularExpressions;

namespace ex_3;

public class InfoObj
{

   public DateTime _data { get; set; }
   private string _LvlLog;

   public string _method = "DEFAULT";
   public string _message = null;
   
   
   public string LogLevel
   {
      get => _LvlLog;
      set => _LvlLog = NormalizeLogLevel(value); // Нормализация только при изменении
   }
   
   
   
   private static string NormalizeLogLevel(string level)
   {
      return level.ToUpper() switch
      {
         "INFORMATION" => "INFO",
         "WARNING" => "WARN",
         _ => level.ToUpper() // Если уровень неизвестен, оставляем как есть
      };
   }
   
   public static InfoObj ParseFromLogLine(string logLine)
   {
      var match = Regex.Match(logLine, 
         @"^(?<timestamp>\d{2}\.\d{2}\.\d{4} \d{2}:\d{2}:\d{2}\.\d{3}) (?<lvl>\w+)\s+(?<message>.+)$",
         RegexOptions.IgnoreCase);

      if (!match.Success)
         throw new FormatException("Некорректный формат лога.");

      return new InfoObj
      {
         _data = DateTime.ParseExact(
            match.Groups["timestamp"].Value,
            "dd.MM.yyyy HH:mm:ss.fff",
            CultureInfo.InvariantCulture),
         LogLevel = match.Groups["lvl"].Value,
         _message = match.Groups["message"].Value.Trim()
      };
   }
   
   public static InfoObj ParseFromStructuredLog(string logLine)
   {
      var parts = logLine.Split('|');
      if (parts.Length < 4)
         throw new FormatException("Некорректный структурированный лог.");

      return new InfoObj
      {
         _data = DateTime.ParseExact(
            parts[0].Trim(),
            "yyyy-MM-dd HH:mm:ss.ffff",
            CultureInfo.InvariantCulture),
         LogLevel = parts[1].Trim(),
         _method = parts[3].Trim(),
         _message = parts.Length > 4 ? parts[4].Trim() : string.Empty
      };
   }
   
   public override string ToString()
   {
      string _time = $"{_data:HH:mm:ss.ffffff}".TrimEnd('0');
      return $"{_data:dd.MM.yyyy}  {_time}  {LogLevel}  {_method}  {_message}";
   }
   
   

}
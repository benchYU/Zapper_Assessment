using Newtonsoft.Json.Linq;
using Serilog.Formatting.Compact.Reader;
using System.Text.RegularExpressions;

namespace ZapperAssessment.Server;

public class LogReaderBase
{
    public List<string> ListUserSettingLogs()
    {
        List<string> userSettingLogs = new List<string>();
        string logDirectory = "Logs";

        var logFilePath = Directory.GetFiles(logDirectory)
                                   .OrderByDescending(f => File.GetLastWriteTime(f))
                                   .FirstOrDefault();


        if (File.Exists(logFilePath))
        {
            // Open the file with FileShare.ReadWrite to avoid the conflict
            using (FileStream fs = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("user setting(s)"))
                    {
                        userSettingLogs.Add(line);
                    }
                }
            }
        }

        return userSettingLogs;
    }
}

public class LogReader : LogReaderBase
{
    public List<string> GetValidUserSettingsLogs()
    {
        List<string> userSettingsLogs = new List<string>();

        userSettingsLogs = ListUserSettingLogs().Where(s => Regex.IsMatch(s, @"\bvalid\b", RegexOptions.IgnoreCase)).ToList();

        return userSettingsLogs;
    }
}

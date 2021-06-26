using System;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        if (files == null || flags == null)
            throw new ArgumentException();

        var list = new List<string>();

        bool caseInsensitive = false;
        bool printFileNamesOnly = false;
        bool printLineNumbers = false;
        bool invertMatch = false;
        bool matchEntireLine = false;

        bool multipleFiles = files.Length > 1;

        foreach (var flag in flags.Split())
        {
            switch (flag)
            {
                case "-i": caseInsensitive = true; break;
                case "-n": printLineNumbers = true; break;
                case "-l": printFileNamesOnly = true; break;
                case "-v": invertMatch = true; break;
                case "-x": matchEntireLine = true; break;
            }
        }

        var regex = new Regex(
            matchEntireLine ? $"^{pattern}$" : pattern,
            caseInsensitive ? RegexOptions.IgnoreCase : 0);

        foreach (var fileName in files)
        {
            var lines = File.ReadAllLines(fileName);

            for (int i = 0; i < lines.Length; i++)
            {
                if (regex.IsMatch(lines[i]) ^ invertMatch)
                {
                    if (printFileNamesOnly)
                    {
                        list.Add(fileName);
                        break;
                    }

                    list.Add(
                        $"{(multipleFiles ? $"{fileName}:" : "")}{(printLineNumbers ? $"{i + 1}:" : "")}{lines[i]}");
                }
            }
        }

        return string.Join("\n", list);
    }
}
using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}\n");
    }

    public string ToCsv()
    {
        return $"{EscapeSpecialCharacters(Date)}|{EscapeSpecialCharacters(Prompt)}|{EscapeSpecialCharacters(Response)}";
    }

    public static Entry FromCsv(string csvLine)
    {
        string[] parts = csvLine.Split('|');

        if (parts.Length != 3)
        {
            throw new FormatException("Invalid CSV format. Each line must have exactly three parts separated by '|'.");
        }

        return new Entry(UnescapeSpecialCharacters(parts[0]), UnescapeSpecialCharacters(parts[1]), UnescapeSpecialCharacters(parts[2]));
    }

    private static string EscapeSpecialCharacters(string input)
    {
        if (input == null) return string.Empty;
        return input.Replace("|", "\\|").Replace("\n", "\\n").Replace("\\", "\\\\");
    }

    private static string UnescapeSpecialCharacters(string input)
    {
        if (input == null) return string.Empty;
        return input.Replace("\\|", "|").Replace("\\n", "\n").Replace("\\\\", "\\");
    }
}

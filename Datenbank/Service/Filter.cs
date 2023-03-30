using System.Collections.Generic;

namespace Datenbank.Service;

public class Filter
{
    public List<string> FilterArguments { get; set; } = new List<string>();

    public void ChangeFilterArguments(string suche)
    {
        FilterArguments.Clear();
        var argumente = suche.Split(' ');

        foreach (var arg in argumente)
        {
            FilterArguments.Add(arg);
        }
    }

    public string[] returnFilterArgsArray()
    {
        return FilterArguments.ToArray();
    }
}

using System.Collections.Generic;
using System.IO;
public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
               outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}|{entry._goal}|{entry._action}");
            }
        }
    }
    public void LoadFromFile(string filename)
{
    _entries.Clear();

    string[] lines = File.ReadAllLines(filename);

    foreach (string line in lines)
    {
        string[] parts = line.Split('|');

        Entry entry = new Entry();
        entry._date = parts[0];
        entry._prompt = parts[1];
        entry._response = parts[2];
        entry._goal = parts.Length > 3 ? parts[3] : "";
        entry._action = parts.Length > 4 ? parts[4] : "";

        _entries.Add(entry);
    }
}
}
public class Entry
{
    public string _date = "";
    public string _prompt = "";
    public string _response = "";

    public string _goal = "";

    public string _action = "";

    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine($"Goal for today: {_goal}");
        Console.WriteLine($"Action for today: {_action}");
    }

    
}
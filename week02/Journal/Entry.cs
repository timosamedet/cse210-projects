using System;

public class Entry{

    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine(_entryText);
        Console.WriteLine(_promptText);
        Console.WriteLine(_date);
    }
}
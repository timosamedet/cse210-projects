using System;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public Boolean _isLoaded = false;
    public int _loadedEntriesCount;
    

    public List<string> menu = new List<string> {"Write","Display", "Load", "Save", "Search", "Quit"};
    public int choice; 

    public void DisplayMenu(){
        Console.WriteLine("Please select one of the following choices:");

        foreach(string item in menu){
                Console.WriteLine($"{menu.IndexOf(item) + 1}. {item}");
        }

        Console.Write("What would you like to do? ");
        choice = int.Parse(Console.ReadLine());

        if(choice == 1){
           WriteMenu();
        }
        else if(choice == 2){
            DisplayAll();
        }
        else if(choice == 3){
            LoadMenu();
        }
        else if(choice == 4){
            SaveMenu();
        }
        else if(choice == 5){
            SearchMenu();
        }
        else if(choice == 6){
            QuitMenu();
        }
        else{
            Console.WriteLine("Invalid Option!");
            DisplayMenu();
        }
    }

    
    public void AddEntry(Entry newEntry){
        _entries.Add(newEntry);
    }

    public void DisplayAll(){
        foreach(Entry entry in _entries){
            Console.WriteLine($"Date: {entry._date}  ---  Prompt: {entry._promptText}");
            Console.WriteLine($"{entry._entryText} \n");
        }
        DisplayMenu();
    }

    public void SaveToFile(string file)
    {
        using(StreamWriter outputFile = new StreamWriter(file)){
            foreach(Entry entry in _entries){
            outputFile.WriteLine($"{entry._date}~~{entry._promptText}~~{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        if(!_isLoaded){
            string[] lines = System.IO.File.ReadAllLines(file);
            foreach(string line in lines){
                string[] entry_parts  = line.Split("~~");
                Entry entry = new Entry();

                entry._date = entry_parts[0];
                entry._promptText = entry_parts[1];
                entry._entryText = entry_parts[2];

                AddEntry(entry);
                _loadedEntriesCount++;
            }

            _isLoaded = true;
        }
    
    }

    public void WriteMenu(){
        PromptGenerator promptGenerator = new PromptGenerator();
        string prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine(prompt); 
        Console.Write("> ");

        string entryText  = Console.ReadLine();

        Entry entry = new Entry();
        entry._entryText = entryText;
        entry._promptText = prompt;

        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        entry._date = dateText;

        AddEntry(entry);
        DisplayMenu();
    }

    public void SaveMenu(){
        Console.WriteLine("What is the file name?");
        string fileName = Console.ReadLine();

        if(!_isLoaded){
            LoadFromFile(fileName);
        }

        SaveToFile(fileName);
        DisplayMenu();
    }

    public void LoadMenu(){
        Console.WriteLine("What is the file name?");
        string fileName = Console.ReadLine();

        LoadFromFile(fileName);
        DisplayMenu();
    }

    public void SearchMenu(){
        Console.WriteLine("Enter search Term: ");
        string searchTerm = Console.ReadLine();

        if(!_isLoaded){
            Console.WriteLine("What is the file name?");
            string fileName = Console.ReadLine();

            LoadFromFile(fileName);
        }
        List<Entry>  searchEntries = _entries.Where(e => e._promptText.Contains(searchTerm) ||  e._entryText.Contains(searchTerm)).ToList();

        foreach(Entry entry in searchEntries){
            Console.WriteLine($"Date: {entry._date}  ---  Prompt: {entry._promptText}");
            Console.WriteLine($"{entry._entryText} \n");
        }
        DisplayMenu();
    }

    public void QuitMenu(){

        if(_loadedEntriesCount < _entries.Count){
            Console.Write("Do you want to save your changes (YES/NO)?  ");
            string saveChanges = Console.ReadLine();

            if(saveChanges.ToLower() == "yes"){

                Console.WriteLine("What is the file name?");
                string fileName = Console.ReadLine();

                SaveToFile(fileName);
                _loadedEntriesCount = _entries.Count;
                Console.WriteLine("Changes saved successfully...");
            }
            else{
                return;
            }
        }
        return;
    }
}

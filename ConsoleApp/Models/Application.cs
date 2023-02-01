namespace ConsoleApp.Models;

public class Application
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Application()
    {

    }

    public Application(string name)
    {
        Name = name;
        Description = $"Description of {name}";
    }

    public Application(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return $"Application: {Name}, Description: {Description}";
    }
}

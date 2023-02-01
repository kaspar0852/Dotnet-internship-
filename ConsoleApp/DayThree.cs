using ConsoleApp.Models;

namespace ConsoleApp;

public static class DayThree
{
    public static void ProgramOne()
    {
        Application app = new Application
        {
            Id = 1,
            Name = "Library",
            Description = "This application helps in assisting a librarian to do day-to-day activities."
        };

        Console.WriteLine("Program One");
        Console.WriteLine($"Application: {app.Name} - {app.Description}");
        Console.WriteLine();
    }

    /// <summary>
    /// Create a list of Applications and print the list to Console
    /// </summary>
    public static void ProgramTwo()
    {
        List<Application> apps = new List<Application>();

        apps.Add(new Application { Id = 1, Name = "One", Description = "One" });
        apps.Add(new Application { Id = 2, Name = "Two", Description = "Two" });
        apps.Add(new Application { Id = 3, Name = "Three", Description = "Three" });

        foreach (var app in apps)
        {
            Console.WriteLine($"{app.Id}. {app.Name} - {app.Description}");
        }
    }

    /// <summary>
    /// ProgramTwo Extended
    /// </summary>
    public static void ProgramThree()
    {
        List<Application> apps = new List<Application>();

        apps.AddRange(new Application[] {
            new Application { Id = 1, Name = "One", Description = "One" },
            new Application { Id = 2, Name = "Two", Description = "Two" },
            new Application { Id = 3, Name = "Three", Description = "Three" },
            new Application { Id = 4, Name = "Four", Description = "Four"},
            new Application { Id = 5, Name = "Five", Description = "Five"},
        });

        
        foreach (var app in apps)
        {
            Console.WriteLine("Privious list");
            Console.WriteLine($"{app.Id}. {app.Name} - {app.Description}");
            
        }
        apps.RemoveAll(x=> x.Id == 4 && x.Id ==5);
        
        foreach(var app in apps)
        {
            Console.WriteLine("Updated list");
            Console.WriteLine($"{app.Id}. {app.Name} - {app.Description}");
            
        }
    }

    public static void ProgramFour()
    {
        Application app = new Application("Test");
        
        Console.WriteLine($"{app.Name}, {app.Description}");

        app.Id = 1;

        Console.WriteLine($"{app.Id}. {app.Name}, {app.Description}");

    }

    public static void ProgramFive()
    {
        Application app = new Application("Test");
        Console.WriteLine(app.ToString());
    }

    public static void ProgramSix()
    {
        List<Application> apps = new List<Application>();

        apps.AddRange(new Application[] {
            new Application { Id = 1, Name = "One", Description = "One" },
            new Application { Id = 2, Name = "Two", Description = "Two" },
            new Application { Id = 3, Name = "Three", Description = "Three" },
        });

        Console.WriteLine($"No. Of Applications: {apps.Count}");
        Console.WriteLine();

        // LINQ: Language INtegrated Query
        var appWithoInName = from app in apps
                                       where app.Name.ToLower().Contains("o")
                                       select app;

        Console.WriteLine($"No. of Apps with o in Name: {appWithoInName.Count()}");


        foreach (var app in appWithoInName)
        {
            Console.WriteLine(app.ToString());
        }
    }

    public static void ProgramSeven()
    {
        List<Application> apps = new List<Application>();

        apps.AddRange(new Application[] {
            new Application { Id = 1, Name = "One", Description = "One" },
            new Application { Id = 2, Name = "Two", Description = "Two" },
            new Application { Id = 3, Name = "Three", Description = "Three" },
            new Application { Id = 4, Name = "Four", Description = "Four" },
            new Application { Id = 5, Name = "Five", Description = "Five"},
        });


        Console.WriteLine($"No. Of Applications: {apps.Count}");
        Console.WriteLine();

        // SELECT * FROM Application;
        var appQuery = from app in apps.AsQueryable() select app;

        // SELECT * FROM Application WHERE Name LIKE ('%o%');
        var nameWitho = appQuery.Where(p => p.Name.ToLower().Contains("o"));

        // SELECT COUNT(*) FROM Application WHERE Name LIKE ('%o%');
        Console.WriteLine($"No. of Apps with o in Name: {nameWitho.Count()}");

        foreach (var app in nameWitho)
        {
            Console.WriteLine(app.ToString());
        }

        Console.WriteLine();

        var nameWithT = appQuery.Where(p => p.Name.ToLower().Contains("t")).ToList();
        

        Console.WriteLine($"No. of Apps with t in Name: {nameWithT.Count()}");

        foreach (var app in nameWithT)
        {
            Console.WriteLine(app.ToString());
        }


        Console.WriteLine();
        



    }
}

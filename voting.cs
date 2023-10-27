using System;
using System.Collections.Generic;

class Contestant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Votes { get; set; } 
}

class DSDSApplication
{
    /
    private static List<Contestant> contestants = new List<Contestant>
    {
        new Contestant { Id = 1, Name = "Luca Haenni" },
        new Contestant { Id = 2, Name = "Daniel Kueblboeck" },
        new Contestant { Id = 3, Name = "Menowin Froehlich" },
        
    };

    static void ViewContestants()
    {
        Console.WriteLine("DSDS Contestants:");
        foreach (var contestant in contestants)
        {
            Console.WriteLine($"{contestant.Id}. {contestant.Name}");
        }
    }

    static void VoteForContestant()
    {
        Console.WriteLine("Enter the ID of the contestant you want to vote for:");
        if (int.TryParse(Console.ReadLine(), out int contestantId))
        {
            var selectedContestant = contestants.Find(c => c.Id == contestantId);
            if (selectedContestant != null)
            {
                selectedContestant.Votes++;
                Console.WriteLine($"You've voted for {selectedContestant.Name}!");
            }
            else
            {
                Console.WriteLine("Invalid contestant ID.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid contestant ID.");
        }
    }

    static void ViewVotingResults()
    {
        Console.WriteLine("Voting Results:");
        foreach (var contestant in contestants)
        {
            Console.WriteLine($"{contestant.Name}: {contestant.Votes} votes");
        }
    }

    static void Main()
    {
        Console.WriteLine("Welcome to Deutschland Sucht den Superstar (DSDS) Application!");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. View Contestants");
        Console.WriteLine("2. Vote for a Contestant");
        Console.WriteLine("3. View Voting Results");
        Console.WriteLine("4. Exit");

        int choice = GetMenuChoice();

        while (choice != 4)
        {
            switch (choice)
            {
                case 1:
                    ViewContestants();
                    break;
                case 2:
                    VoteForContestant();
                    break;
                case 3:
                    ViewVotingResults();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Please select an option:");
            choice = GetMenuChoice();
        }

        Console.WriteLine("Exiting the DSDS Application. Goodbye!");
    }

    static int GetMenuChoice()
    {
        Console.Write("Enter your choice (1-4): ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 4)
            {
                return choice;
            }
            else
            {
                Console.Write("Invalid input. Please enter a valid choice (1-4): ");
            }
        }
    }
}
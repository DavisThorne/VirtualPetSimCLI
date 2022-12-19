using VirtualPetSimCLI.main;
using static System.ConsoleKey;

namespace VirtualPetSimCLI;

public static class MainMenu
{
    public static void Main()
    {
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Start a new game");
        Console.WriteLine("2. Load a game");
        Console.WriteLine("3. Play Demo (No Saving!)");
        Console.WriteLine("0. Exit");
        ConsoleKeyInfo choice = Console.ReadKey();
        switch (choice)
        {
            case var _ when choice.Key == D1:
                Console.Clear();
                Console.WriteLine("Starting a new game...");
                CreateNewGame.Create();
                break;
            case var _ when choice.Key == D2:
                Console.Clear();
                Console.WriteLine("Loading a game...");
                //LoadGame.Main();
                break;
            case var _ when choice.Key == D3:
                Console.Clear();
                Console.WriteLine("Loading Demo...");
                Demo.DemoMenu();
                break;
            case var _ when choice.Key == D0:
                Console.Clear();
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}



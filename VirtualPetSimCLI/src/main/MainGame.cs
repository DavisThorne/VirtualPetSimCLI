using static System.ConsoleKey;
using static VirtualPetSimCLI.main.SaveData;
namespace VirtualPetSimCLI.main;

public abstract class PetParams
{
    public static string CharacterNameLocal = CharacterName;
    public static string PetNameLocal = PetName;
    public static string PetSpeciesLocal = PetSpecies;
    public static int PetAgeLocal = PetAge;
    public static int PetHungerLocal = PetHunger;
    public static int PetThirstLocal = PetThirst;
    public static int PetHappinessLocal = PetHappiness;
    public static int PetHealthLocal = PetHealth;
    public static int PetEnergyLocal = PetEnergy;
    public static int PetCleanlinessLocal = PetCleanliness;
}

public static class MainGame
{

    public static void StartThreadedLoops()
    {
        Thread threadedLoops = new(ThreadedClass.RunThreadedLoops);
        threadedLoops.Start();
        MainGameMenu();
    }
    
    public static void MainGameMenu()
    {
        Thread threadedLoops = new(ThreadedClass.RunThreadedLoops);
        threadedLoops.Start();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Virtual Pet Simulator!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine($"1. Play with {PetParams.PetNameLocal}");
            Console.WriteLine($"2. Feed {PetParams.PetNameLocal}");
            Console.WriteLine($"3. Give {PetParams.PetNameLocal} a bath");
            Console.WriteLine($"4. Put {PetParams.PetNameLocal} to bed");
            Console.WriteLine($"5. Check {PetParams.PetNameLocal}'s stats");
            Console.WriteLine("6. Save and quit");
            Console.WriteLine("0. Quit without saving");
            Console.Write("Enter your choice: ");
            ConsoleKeyInfo choice = Console.ReadKey();
            
            switch (choice)
            {
                case var _ when choice.Key == D1:
                    PlayWithPet();
                    break;
                case var _ when choice.Key == D2:
                    FeedPet();
                    break;
                case var _ when choice.Key == D3:
                    GivePetBath();
                    break;
                case var _ when choice.Key == D4:
                    PutPetToBed();
                    break;
                case var _ when choice.Key == D5:
                    Console.Clear();
                    CheckPetStats();
                    break;
                case var _ when choice.Key == D6:
                    SaveGame.Save();
                    Environment.Exit(0);
                    break;
                case var _ when choice.Key == D0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void CheckPetStats()
    {
        Console.WriteLine($"Pet age: {PetParams.PetAgeLocal} \nPet hunger: {PetParams.PetHungerLocal} \nPet thirst: {PetParams.PetThirstLocal} " +
                          $"\nPet happiness: {PetParams.PetHappinessLocal} \nPet health: {PetParams.PetHealthLocal} " +
                          $"\nPet energy: {PetParams.PetEnergyLocal} \nPet cleanliness: {PetParams.PetCleanlinessLocal}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        MainGameMenu();
    }

    private static void PutPetToBed()
    {
        throw new NotImplementedException();
    }

    private static void GivePetBath()
    {
        throw new NotImplementedException();
    }

    private static void FeedPet()
    {
        throw new NotImplementedException();
    }

    private static void PlayWithPet()
    {
        throw new NotImplementedException();
    }
}
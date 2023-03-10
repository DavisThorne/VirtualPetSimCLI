using static System.ConsoleKey;
using static VirtualPetSimCLI.main.SaveData;


namespace VirtualPetSimCLI.main;

public abstract class Demo
{
    public static int petAge = PetAge;
    public static int petHunger = PetHunger;
    
    
    
    public static void DemoMenu()
    {
        Thread threadedLoops = new(ThreadedClass.RunThreadedLoops);
        threadedLoops.Start();
        
        while (true)
        {
            const string petName = "Buddy";
            const string petType = "Dog";


            Console.Clear();
            Console.WriteLine("Welcome to the Virtual Pet Simulator!");
            Console.WriteLine($"You have a {petType} named {petName}.");
            Console.WriteLine($"Your pet is {petAge} years old.");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Feed your pet");
            Console.WriteLine("2. Play with your pet");
            Console.WriteLine("3. Put your pet to bed");
            Console.WriteLine("4. Check pet age");
            Console.WriteLine("0. Exit the program");
            Console.Write("Please enter your choice: ");
            ConsoleKeyInfo choice = Console.ReadKey();
            switch (choice)
            {
                case var _ when choice.Key == D1:
                    Console.Clear();
                    Console.WriteLine("You fed your pet.");
                    break;
                case var _ when choice.Key == D2:
                    Console.Clear();
                    Console.WriteLine("You played with your pet.");
                    break;
                case var _ when choice.Key == D3:
                    Console.Clear();
                    Console.WriteLine("You put your pet to bed.");
                    break;
                case var _ when choice.Key == D4:
                    Console.Clear();
                    Console.WriteLine($"Your pet is {petAge} years old.");
                    break;
                case var _ when choice.Key == D0:
                    Console.Clear();
                    Console.WriteLine("You exited the program.");
                    Console.Clear();
                    MainMenu.Main();
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}


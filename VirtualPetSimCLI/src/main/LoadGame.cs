using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace VirtualPetSimCLI.main;

internal class Pet
{
    public static string FullFilePath { get; set; } = null!;
    public string CharacterName { get; set; } = null!;
    public string PetName { get; set; } = null!;
    public string PetSpecies { get; set; } = null!;
    public int PetAge { get; set; }
    public int PetHunger { get; set; }
    public int PetThirst { get; set; }
    public int PetHappiness { get; set; }
    public int PetHealth { get; set; }
    public int PetEnergy { get; set; }
    public int PetCleanliness { get; set; }
}

public class LoadGame
{
    public static void Load()
    {
        int counter = 0;
        string rootPath = Environment.ExpandEnvironmentVariables($"%LOCALAPPDATA%\\PetSimCLI\\");
        string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
        Console.WriteLine($"List Of Found Save Files in {rootPath}");
        
        foreach (string dir in dirs)
        { ;
            counter++;
            string fullPath = Path.GetFullPath(dir).TrimEnd(Path.DirectorySeparatorChar);
            string saveName  = fullPath.Split(Path.DirectorySeparatorChar).Last();
            Console.WriteLine($"{counter}. {saveName}");
        }

        Console.WriteLine("Which character would you like to load? (USE NAME)");
        string characterNameLocal = Console.ReadLine()!;
        string tempFilePath = Environment.ExpandEnvironmentVariables($"%LOCALAPPDATA%\\PetSimCLI\\{characterNameLocal}");
        DirectoryInfo directory = new(tempFilePath); //Assuming Test is your Folder

        FileInfo[] files = directory.GetFiles("*.json"); //Getting Text files
        string fileName = "";
        foreach(FileInfo file in files )
        { 
            fileName = $"{file.Name}";
        }
        SaveData.FullFilePath = Environment.ExpandEnvironmentVariables($"%LOCALAPPDATA%\\PetSimCLI\\{characterNameLocal}\\{fileName}");
        Console.WriteLine($"Loading {characterNameLocal} from {SaveData.FullFilePath}...");
        Thread.Sleep(300);
        Console.Clear();
        JsonParser();
    }

    private static void JsonParser()
    {
        string json = File.ReadAllText(SaveData.FullFilePath);
        Pet pet = JsonConvert.DeserializeObject<Pet>(json)!;
        Console.WriteLine($"Loaded {pet.PetName}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        SaveDataUpdate(pet);
    }

    private static void SaveDataUpdate(Pet pet)
    {
        SaveData.PetName = pet.PetName;
        SaveData.PetSpecies = pet.PetSpecies;
        SaveData.PetAge = pet.PetAge;
        SaveData.PetHunger = pet.PetHunger;
        SaveData.PetThirst = pet.PetThirst;
        SaveData.PetHappiness = pet.PetHappiness;
        SaveData.PetHealth = pet.PetHealth;
        SaveData.PetEnergy = pet.PetEnergy;
        SaveData.PetCleanliness = pet.PetCleanliness;
        SaveData.CharacterName = pet.CharacterName;
        MainGame.StartThreadedLoops();
    }
}
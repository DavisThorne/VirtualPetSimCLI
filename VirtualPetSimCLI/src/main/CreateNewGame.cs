using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace VirtualPetSimCLI.main;

public static class DefaultStartingValues
{
    public static void DefaultValues()
    {
        // Place the default values for the SaveData.cs class here.
        SaveData.PetAge = 0;
        SaveData.PetHunger = 100;
        SaveData.PetThirst = 100;
        SaveData.PetHappiness = 100;
        SaveData.PetHealth = 100;
        SaveData.PetEnergy = 100;
        SaveData.PetCleanliness = 100;
        DataHandling.Inputs();
    }
}

public static class DataHandling
{
    public static void Inputs()
    {
        Console.WriteLine("Please enter your character's name");
        SaveData.CharacterName = Console.ReadLine()!;
        Console.WriteLine("Please enter your pets name");
        SaveData.PetName = Console.ReadLine()!;
        Console.WriteLine("Please enter your pets species");
        SaveData.PetSpecies = Console.ReadLine()!;
        Console.WriteLine();
        CreateNewGame.Create();
    }
}

public static class CreateNewGame
{
    public static void Create()
    {
        string characterName = SaveData.CharacterName;
        Console.WriteLine(characterName);
        var userDataPath = Environment.ExpandEnvironmentVariables($"%LOCALAPPDATA%\\PetSimCLI\\{SaveData.CharacterName}");
        var userDataFile = $"{SaveData.CharacterName}-{DateTime.Today:dd-MM-yyyy}.json";
        var fullFilePath = Path.Combine(userDataPath, userDataFile);
        SaveData.FullFilePath = fullFilePath;

        if (!Directory.Exists(userDataPath))
        {
            Directory.CreateDirectory(userDataPath);
        }

        if (!File.Exists(fullFilePath))
        {
            File.Create(fullFilePath).Dispose();
        }

        Console.WriteLine($"User data file created at {fullFilePath}");
        JsonParser(fullFilePath);
    }

    private static void JsonParser(string fullFilePath)
    {
        
        using (FileStream fs = File.Open(fullFilePath, FileMode.Open))
        {
            Byte[] jsonEmpty = new UTF8Encoding(true).GetBytes("{}");
            fs.Write(jsonEmpty);
        }

        using (StreamWriter file = new StreamWriter(File.Open(fullFilePath, FileMode.Open)))
        {
            var json = file.ToString();
            var jObject = JObject.FromObject(new {
                SaveData.CharacterName,
                SaveData.PetName,
                SaveData.PetSpecies,
                SaveData.PetAge,
                SaveData.PetHunger,
                SaveData.PetThirst,
                SaveData.PetHappiness,
                SaveData.PetHealth,
                SaveData.PetEnergy,
                SaveData.PetCleanliness
            });
            string jsonSaveData = JsonConvert.SerializeObject(jObject, Formatting.Indented);
            //File.WriteAllText(fullFilePath, jsonSaveData); 
            file.Write(jsonSaveData);
        }
        MainGame.StartThreadedLoops();
    }
}


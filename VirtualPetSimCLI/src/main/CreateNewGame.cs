using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.IO.FileMode;
namespace VirtualPetSimCLI.main;

public static class DataHandling
{
    public static void Inputs()
    {
        
        Console.WriteLine("Please enter your character's name");
        SaveData.CharacterName = Console.ReadLine()!;
        Console.WriteLine("Please enter your pets name");
        SaveData.PetName = Console.ReadLine()!;
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
        if (!Directory.Exists(userDataPath))
        {
            Directory.CreateDirectory(userDataPath);
        }

        if (!File.Exists(fullFilePath))
        {
            File.Create(fullFilePath);
        }

        Console.WriteLine($"User data file created at {fullFilePath}");
    } 
}

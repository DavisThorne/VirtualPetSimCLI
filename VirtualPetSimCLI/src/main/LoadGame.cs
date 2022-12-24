using static VirtualPetSimCLI.main.SaveData;
using System.Linq;
namespace VirtualPetSimCLI.main;

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
        FullFilePath = Environment.ExpandEnvironmentVariables($"%LOCALAPPDATA%\\PetSimCLI\\{characterNameLocal}\\{fileName}");
        Console.WriteLine($"Loading {characterNameLocal} from {FullFilePath}...");
    }
}
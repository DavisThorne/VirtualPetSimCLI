using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VirtualPetSimCLI.main;

public abstract class SaveGame
{
    public static void Save()
    {
        var fullFilePath = SaveData.FullFilePath;
        using (StreamWriter file = new StreamWriter(File.Open(fullFilePath, FileMode.Open)))
        {
            var jObject = JObject.FromObject(new
            {
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
            file.Write(jsonSaveData);
        }
    }
}
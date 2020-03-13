using UnityEngine;
using System.IO; // Necessary for working with files
using System.Runtime.Serialization.Formatters.Binary; // Allows for binary formatting

public static class SaveManager
{
    static string path = Application.persistentDataPath + "/PlayerData.bin";
    public static void SaveState (GameLoop gameLoop)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gameLoop);

        formatter.Serialize(file, data);
        file.Close();
    }

    public static PlayerData LoadState()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(file) as PlayerData;
            file.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in: " + path);
            return null;
        }
    }
}

// Author Santeri Mikkola

using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void GenerateSaveFile(CarCollider carCollider)
    {
        if (!File.Exists(Application.persistentDataPath + "/data.saved"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/data.saved";
            FileStream stream = new FileStream(path, FileMode.Create);

            GameData data = new GameData(carCollider);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public static void SaveData(CarCollider carCollider)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.saved";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(carCollider);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/data.saved";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "MyData.txt";

    public static void Save(JugadorInfo so)
    {
        string dir = Application.persistentDataPath + directory;

        if(!Directory.Exists(dir)) {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }

    public static JugadorInfo Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        JugadorInfo so = new JugadorInfo();

        if(File.Exists(fullPath)) 
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<JugadorInfo>(json);
        }
        else
        {
            Debug.Log("No existe el archivo de guardado");
        }

        return so;
    }
    
}

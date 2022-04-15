using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class Deserializer : MonoBehaviour
{
    private SomeData[] data;
    private const string PATH = @"C:\Users\Антон\Desktop\My projects\JSONs\Assets\Resources\DataBase_Parsed.txt";

    private SomeData[] DeserializedDB()
    {
        using (StreamReader file = File.OpenText(PATH))
        {
            JsonSerializer serializer = new JsonSerializer();
            SomeDataBase db = (SomeDataBase)serializer.Deserialize(file, typeof(SomeDataBase));
            data = db.SomeDB;
        }

        return data;
    }
    private void Start()
    {
        SomeData[] db = DeserializedDB();
        foreach(SomeData data in db)
        {
            Debug.Log($"{data.Name} {data.Description}");
        }
    }
}

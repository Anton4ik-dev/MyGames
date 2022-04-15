using Newtonsoft.Json;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    private const string PATH = @"C:\Users\Антон\Documents\MyGames\JSONs\Assets\Resources\DataBase_Parsed.txt";
    public static void ParseCSV()
    {
        TextAsset content = Resources.Load<TextAsset>("DataBase");

        string contentString = content.text;
        string[] contentLines = contentString.Split('\n');

        List<SomeData> someDB = new List<SomeData>();
        foreach(string line in contentLines)
        {
            string[] word = line.Split(',');
            someDB.Add(new SomeData(word[0], word[1]));
        }

        SomeDataBase db = new SomeDataBase(someDB.ToArray());

        JsonSerializer serializer = new JsonSerializer();
        serializer.Formatting = Formatting.Indented;

        using (StreamWriter sw = new StreamWriter(PATH))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, db);
        }
    }
}
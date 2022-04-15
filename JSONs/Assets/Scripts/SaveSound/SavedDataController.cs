using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;

public class SavedDataController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private const string PATH = @"C:\Users\Антон\Documents\MyGames\JSONs\Assets\Resources\SoundData.txt";
    private JsonSerializer serializer = new JsonSerializer();
    private void Start()
    {
        serializer.Formatting = Formatting.Indented;
        if (Resources.Load<TextAsset>("SoundData") == null)
        {
            using (StreamWriter sw = new StreamWriter(PATH))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, audioSource.volume);
            }
        } else
        {
            TextAsset content = Resources.Load<TextAsset>("SoundData");
            string contentString = content.text;
            Debug.Log(contentString);
            audioSource.GetComponent<AudioSource>().volume = float.Parse(contentString, CultureInfo.InvariantCulture.NumberFormat); ;
        }
    }

    private void Update()
    {
        serializer.Formatting = Formatting.Indented;
        using (StreamWriter sw = new StreamWriter(PATH))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, audioSource.volume);
        }
    }
}

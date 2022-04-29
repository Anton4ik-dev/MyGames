using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using UnityEngine.SceneManagement;

public class InventoryScript : MonoBehaviour
{
    private string PATH;
    private JsonSerializer serializer = new JsonSerializer();

    [SerializeField] private GameObject itemPrefab;
    public int howManyItemsCreated = 0;
    private int rnd;
    [Range(1, 10)]
    [SerializeField]private int howManyItems;
    private Object[] itemDataHelp;
    [HideInInspector] public ItemSO[] itemData;
    private int[] test;


    private void Awake()
    {
        PATH = Application.persistentDataPath + "/SONumbers.txt";
        itemDataHelp = Resources.LoadAll("Items", typeof(ItemSO));
        itemData = new ItemSO[itemDataHelp.Length];
        for (int i = 0; i < itemDataHelp.Length; i++)
        {
            itemData[i] = (ItemSO)itemDataHelp[i];
        }
    }
    private void Start()
    {
        serializer.Formatting = Formatting.Indented;
        if (PlayerPrefs.GetInt("save", 1) == 1)
        {
            PlayerPrefs.SetInt("save", 0);
            using (StreamWriter sw = new StreamWriter(PATH))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, null);
            }
        }
        else
        {
            string content = File.ReadAllText(PATH);
            string[] contentString = content.Split(',', '[', ']', ' ');
            for (int i = 0, cnt = 0; i < contentString.Length; i++)
            {
                bool check = int.TryParse(contentString[i].ToString(), out int res);
                if (check && res != -1)
                {
                    itemPrefab.GetComponent<Image>().sprite = itemData[res].ItemSprite;
                    Instantiate(itemPrefab, transform.GetChild(0));
                    transform.GetChild(0).GetChild(cnt).GetComponent<Item>().whereToPutDataSaver = itemData[res];
                    transform.GetChild(0).GetChild(cnt).GetComponent<Item>().itemSONum = res;
                    cnt++;
                }
            }
            howManyItemsCreated = transform.GetChild(0).childCount;
            fillArr();
        }
    }
    public void OpenChaest()
    {
        howManyItemsCreated = transform.GetChild(0).childCount;
        if(howManyItemsCreated < howManyItems)
        {
            rnd = Random.Range(0, 11);
            if(itemData[rnd].name == "VoidChest")
            {
                for (int i = 0; i < howManyItemsCreated; i++)
                {
                    Destroy(transform.GetChild(0).GetChild(i).gameObject);
                }
                serializer.Formatting = Formatting.Indented;
                using (StreamWriter sw = new StreamWriter(PATH))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, null);
                }
                return;
            }
            itemPrefab.GetComponent<Image>().sprite = itemData[rnd].ItemSprite;
            Instantiate(itemPrefab, transform.GetChild(0));
            transform.GetChild(0).GetChild(howManyItemsCreated).GetComponent<Item>().whereToPutDataSaver = itemData[rnd];
            transform.GetChild(0).GetChild(howManyItemsCreated).GetComponent<Item>().itemSONum = rnd;
            fillArr();
            SceneManager.LoadScene(0);
        }
    }
    public void fillArr()
    {
        howManyItemsCreated = transform.GetChild(0).childCount;
        test = new int[howManyItemsCreated];
        for (int i = 0; i < test.Length; i++)
        {
            int z = transform.GetChild(0).GetChild(i).GetComponent<Item>().itemSONum;
            if(z != -1)
            {
                test[i] = z;
            } else
            {
                test[i]--;
            }
        }
        serializer.Formatting = Formatting.Indented;
        using (StreamWriter sw = new StreamWriter(PATH))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, test);
        }
    }
}
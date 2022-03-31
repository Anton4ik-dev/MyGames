using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    private int howManyItemsCreated = 0;
    private int rnd;
    [Range(1, 10)]
    [SerializeField]private int howManyItems;
    private Object[] itemDataHelp;
    [HideInInspector] public ItemSO[] itemData;

    private void Start()
    {
        itemDataHelp = Resources.LoadAll("Items", typeof(ItemSO));
        itemData = new ItemSO[itemDataHelp.Length];
        for (int i = 0; i < itemDataHelp.Length; i++)
        {
            itemData[i] = (ItemSO)itemDataHelp[i];
        }
    }

    public void OpenChaest()
    {
        if(howManyItemsCreated < howManyItems)
        {
            rnd = Random.Range(0, 10);
            itemPrefab.GetComponent<Image>().sprite = itemData[rnd].ItemSprite;
            Instantiate(itemPrefab, transform.GetChild(0));
            Item.whereToPutDataSaver = itemData[rnd];
            howManyItemsCreated++;
        }
    }
}
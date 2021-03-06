using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [HideInInspector] public ItemSO whereToPutDataSaver;
    [HideInInspector] public int itemSONum;
    private InventoryScript scr;
    private ItemSO whereToPutData;
    private Transform path;
    private void Start()
    {
        scr = transform.parent.parent.GetComponent<InventoryScript>();
        path = transform.parent.parent.GetChild(2);
        whereToPutData = whereToPutDataSaver;
    }

    public void DestroyOnClick()
    {
        Destroy(gameObject);
        itemSONum = -1;
        scr.fillArr();
        SceneManager.LoadScene(0);
        OnMouseExitEvent();
    }

    public void OnMouseOverEvent()
    {
        path.GetChild(0).GetComponent<Image>().sprite = whereToPutData.ItemSprite;
        path.GetChild(1).GetComponent<Text>().text = whereToPutData.ItemCost.ToString();
        path.GetChild(4).GetComponent<Text>().text = whereToPutData.ItemName.ToString();
        path.GetChild(2).GetComponent<Text>().text = whereToPutData.ItemSpecial.ToString();
        path.GetChild(3).GetComponent<Text>().text = whereToPutData.TypeOfItem.ToString();
        path.gameObject.SetActive(true);
    }

    public void OnMouseExitEvent()
    {
        path.gameObject.SetActive(false);
    }
}
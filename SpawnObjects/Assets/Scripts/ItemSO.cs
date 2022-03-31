using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ItemData")]
public class ItemSO : ScriptableObject
{
    public enum TypeOf{armor, weapon, consumable, material}

    [SerializeField] private Sprite itemSprite;
    [SerializeField] private TypeOf typeOfItem;
    [SerializeField] private string itemName;
    [SerializeField] private int itemCost;
    [SerializeField] private int itemSpecial;

    public string ItemName
    {
        get
        {
            return itemName;
        }
    }

    public Sprite ItemSprite
    {
        get
        {
            return itemSprite;
        }
    }

    public int ItemCost
    {
        get
        {
            return itemCost;
        }
    }

    public int ItemSpecial
    {
        get
        {
            return itemSpecial;
        }
    }

    public TypeOf TypeOfItem
    {
        get
        {
            return typeOfItem;
        }
    }

}
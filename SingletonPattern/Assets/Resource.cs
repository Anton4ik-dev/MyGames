using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public Resources.Types _resourceType;
    public int _amountOfResources;
    public Resource(int amount, int type)
    {
        _amountOfResources = amount;
        if(type == 0)
        {
            _resourceType = Resources.Types.Gold;
        } else if(type == 1)
        {
            _resourceType = Resources.Types.Stone;
        } else if(type == 2)
        {
            _resourceType = Resources.Types.Silver;
        }
        else if (type == 3)
        {
            _resourceType = Resources.Types.Wood;
        }
        else if (type == 4)
        {
            _resourceType = Resources.Types.Bronze;
        }
    }
}
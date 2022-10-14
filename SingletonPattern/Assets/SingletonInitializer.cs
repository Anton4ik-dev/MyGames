using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonInitializer
{
    public static SingletonInitializer instance = new SingletonInitializer();
    private Dictionary<Resources.Types, Resource> _resorcesDictionary = new Dictionary<Resources.Types, Resource>()
    {
        [Resources.Types.Gold] = new Resource(15, 0),
        [Resources.Types.Stone] = new Resource(53, 0),
        [Resources.Types.Silver] = new Resource(10, 0),
        [Resources.Types.Wood] = new Resource(104, 0),
        [Resources.Types.Bronze] = new Resource(37, 0),
    };
    private int GetResourceAmount(Resources.Types resourceType) => _resorcesDictionary[resourceType]._amountOfResources;
    public void AddResources(Resources.Types resourceType, int addition)
    {
        Debug.Log(resourceType);
        Debug.Log(_resorcesDictionary[resourceType]._amountOfResources);
        _resorcesDictionary[resourceType]._amountOfResources += addition;
        Debug.Log(addition);
        Debug.Log(_resorcesDictionary[resourceType]._amountOfResources);
    }
}
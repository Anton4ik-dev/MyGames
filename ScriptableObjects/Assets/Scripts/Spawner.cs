using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPointPool _spawnPointsPoolComponent;
    private ObjectPool objectPool;
    private GameObject prefab;

    void Awake()
    {
        objectPool = new ObjectPool(_spawnPointsPoolComponent);
        objectPool.InitPool();

        prefab = Resources.Load("ObjectToSpawn") as GameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Spawn();
    }

    private void Spawn()
    {
        Transform currPoint = objectPool.GetPoolObject();
        GameObject newObject = Instantiate(prefab, currPoint);
        ObjectToSpawn newObjectComponent = newObject.GetComponent<ObjectToSpawn>();
        newObjectComponent.Construct(objectPool, currPoint);
    }
}

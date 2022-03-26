using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool
{
    private Queue<Transform> poolQueue = new Queue<Transform>();
    private SpawnPointPool spawnPointsPool;

    public ObjectPool(SpawnPointPool spawnPointsPool)
    {
        this.spawnPointsPool = spawnPointsPool;
    }
    public void InitPool()
    {
        List<Transform> pool = spawnPointsPool.spawnPoints;
        pool = pool.OrderBy(x => Random.value).ToList();

        foreach (Transform item in pool)
            poolQueue.Enqueue(item);
    }

    public Transform GetPoolObject() => poolQueue.Dequeue();

    public void ReturnToPool(Transform item) => poolQueue.Enqueue(item);
}

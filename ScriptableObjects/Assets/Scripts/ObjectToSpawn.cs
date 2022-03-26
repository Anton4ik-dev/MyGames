using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToSpawn : MonoBehaviour
{
    private ObjectPool objectPool;
    private Transform currTransform;

    public void Construct(ObjectPool pool, Transform point)
    {
        objectPool = pool;
        currTransform = point;
    }

    public void OnMouseDown()
    {
        Destroy(gameObject);
        objectPool.ReturnToPool(currTransform);
    }
}

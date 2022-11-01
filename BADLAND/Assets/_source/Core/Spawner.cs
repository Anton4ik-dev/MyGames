using System.Collections;
using UnityEngine;

namespace Core
{
    public class Spawner
    {
        private Vector3 _distance = new Vector3();
        public GameObject SpawnPlayer(GameObject prefab)
        {
            GameObject spawnedObject = GameObject.Instantiate(prefab);
            return spawnedObject;
        }
        public void SpawnPart(GameObject prefab)
        {
            GameObject.Instantiate(prefab, _distance, Quaternion.identity);
            _distance.x += prefab.transform.localScale.x;
        }
    }
}
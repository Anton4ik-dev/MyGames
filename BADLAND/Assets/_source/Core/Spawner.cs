using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Spawner
    {
        private Vector3 _distance = Vector3.zero;
        public GameObject SpawnPlayer(GameObject prefab)
        {
            GameObject spawnedObject = GameObject.Instantiate(prefab);
            return spawnedObject;
        }
        public void SpawnPart(GameObject prefab)
        {
            _distance.x -= prefab.GetComponent<PartInfo>().StartPoint.position.x;
            GameObject spawnedObject = GameObject.Instantiate(prefab, _distance, new Quaternion());
            TurnOffRandomObjects(spawnedObject, 2);
            _distance.x += prefab.GetComponent<PartInfo>().FinishPoint.position.x;
        }
        private void TurnOffRandomObjects(GameObject spawnedObject, int howManyToTurnOff)
        {
            List<GameObject> objects = spawnedObject.GetComponent<PartInfo>().Objects;
            for (int i = 0; i < howManyToTurnOff; i++)
            {
                int rnd = Random.Range(0, objects.Count);
                GameObject.Destroy(objects[rnd]);
                objects.RemoveAt(rnd);
            }
        }
    }
}
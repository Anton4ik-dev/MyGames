using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawns
{
    public class PartInfo : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        public Transform StartPoint { get => _startPoint; }
        [SerializeField] private Transform _finishPoint;
        public Transform FinishPoint { get => _finishPoint; }
        [SerializeField] private List<GameObject> _objects;
        public List<GameObject> Objects { get => _objects; }
    }
}

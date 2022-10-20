using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResourcePresentation
{
    [CreateAssetMenu(fileName = "NewResourceSO", menuName = "SO/NewResource")]
    public class ResourceSO : ScriptableObject
    {
        [SerializeField] private List<ResourceData> _resources;
        public List<ResourceData> Resources => _resources;
    }

    [Serializable]
    public class ResourceData
    {
        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private float _resourceEnrichment;
        [SerializeField] private float _resourceDecay;

        public ResourceType ResourceType => _resourceType;
        public float ResourceEnrichment => _resourceEnrichment;
        public float ResourceDecay => _resourceDecay;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResourcePresentation
{
    [CreateAssetMenu(fileName = "NewResourcePresentationSO", menuName = "SO/NewResourcePresentation")]
    public class ResourcePresentationSO : ScriptableObject
    {
        [SerializeField] private List<ResourcePresentationData> _resources;
        public List<ResourcePresentationData> Resources => _resources;
    }

    [Serializable]
    public class ResourcePresentationData
    {
        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private Sprite _enabledIcon;
        [SerializeField] private Sprite _disabledIcon;

        public ResourceType ResourceType => _resourceType;
        public Sprite EnabledIcon => _enabledIcon;
        public Sprite DisabledIcon => _disabledIcon;
    }
}
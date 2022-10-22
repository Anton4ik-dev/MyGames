using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ResourcePresentation;

namespace Services
{
    public sealed class DataService
    {
        private ResourceSO resourcesSO;
        private string RESOURCE_DATA_PATH = "ResourceData/MyResourcesData";
        private DataService()
        {
            LoadResources();
        }
        private static DataService source = null;
        public static DataService Source
        {
            get
            {
                if (source == null)
                    source = new DataService();

                return source;
            }
        }

        public float GetEnrichmentTime(ResourceType resourceType)
        {
            for (int i = 0; i < resourcesSO.Resources.Count; i++)
            {
                if (resourcesSO.Resources[i].ResourceType == resourceType)
                {
                    return resourcesSO.Resources[i].ResourceEnrichment;
                }
            }
            return 0;
        }
        public float GetDecayTime(ResourceType resourceType)
        {
            for (int i = 0; i < resourcesSO.Resources.Count; i++)
            {
                if (resourcesSO.Resources[i].ResourceType == resourceType)
                {
                    return resourcesSO.Resources[i].ResourceDecay;
                }
            }
            return 0;
        }
        private void LoadResources()
        {
            resourcesSO = Resources.Load(RESOURCE_DATA_PATH, typeof(ResourceSO)) as ResourceSO;
        }
    }
}
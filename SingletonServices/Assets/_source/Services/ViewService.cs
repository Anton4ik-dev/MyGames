using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ResourcePresentation;

namespace Services
{
    public sealed class ViewService
    {
        private ResourcePresentationSO resourcePresentationSO;
        private string RESOURCE_PRESENTATION_PATH = "ResourcePresentation/MyResourcePresentation";
        private ViewService()
        {
            LoadResourcePresentation();
        }
        private static ViewService source = null;
        public static ViewService Source
        {
            get
            {
                if (source == null)
                    source = new ViewService();

                return source;
            }
        }

        public void SetEnabledSprite(GameObject whatToChange)
        {
            ResourceType whatResourceType = whatToChange.GetComponent<EnrichmentAndDecayLogic>().ResourceType;
            for (int i = 0; i < resourcePresentationSO.Resources.Count; i++)
            {
                if(resourcePresentationSO.Resources[i].ResourceType == whatResourceType)
                {
                    whatToChange.GetComponent<Image>().sprite = resourcePresentationSO.Resources[i].EnabledIcon;
                    break;
                }
            }
        }
        public void SetDisabledSprite(GameObject whatToChange)
        {
            ResourceType whatResourceType = whatToChange.GetComponent<EnrichmentAndDecayLogic>().ResourceType;
            for (int i = 0; i < resourcePresentationSO.Resources.Count; i++)
            {
                if (resourcePresentationSO.Resources[i].ResourceType == whatResourceType)
                {
                    whatToChange.GetComponent<Image>().sprite = resourcePresentationSO.Resources[i].DisabledIcon;
                    break;
                }
            }
        }
        private void LoadResourcePresentation()
        {
            resourcePresentationSO = Resources.Load(RESOURCE_PRESENTATION_PATH, typeof(ResourcePresentationSO)) as ResourcePresentationSO;
        }
    }
}
using ResourcePresentation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public sealed class TimerService : MonoBehaviour
    {
        private List<EnrichmentAndDecay> resourceButton = new List<EnrichmentAndDecay>();
        public static Action OnPlayerLose;

        public static TimerService Source { get; private set; }
        private void Awake()
        {
            if (Source != null && Source != this)
                Destroy(gameObject);
            else
            {
                Source = this;
            }
        }
        private void Update()
        {
            for (int i = 0; i < resourceButton.Count; i++)
            {
                resourceButton[i].Timer.value -= Time.deltaTime;


                if (resourceButton[i].Timer.value <= 0)
                {
                    if (resourceButton[i].Button.interactable)
                    {
                        OnPlayerLose?.Invoke();
                    }
                    else
                    {
                        SetTimeToDecayTimer(resourceButton[i]);
                    }
                }
            }
            

        }

        public void StartTimer(EnrichmentAndDecay enrichmentAndDecay)
        {
            resourceButton.Add(enrichmentAndDecay);
            SetTimeToDecayTimer(enrichmentAndDecay);
        }
        public void SetTimeToDecayTimer(EnrichmentAndDecay enrichmentAndDecay)
        {
            enrichmentAndDecay.StartDecayTimer(); // action не стал использовать т.к возникала проблема, что он вызывался у всех кнопок сразу, поэтому лучше паблик методом решил
            enrichmentAndDecay.Timer.maxValue = enrichmentAndDecay.DecayTime;
            enrichmentAndDecay.Timer.value = enrichmentAndDecay.DecayTime;
        }
        public void SetTimeToEnrichmentTimer(EnrichmentAndDecay enrichmentAndDecay)
        {
            enrichmentAndDecay.Timer.maxValue = enrichmentAndDecay.EnrichmentTime;
            enrichmentAndDecay.Timer.value = enrichmentAndDecay.EnrichmentTime;
        }
    }
}
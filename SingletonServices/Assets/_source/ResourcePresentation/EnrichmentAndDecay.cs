using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;
using Services;
using System;

namespace ResourcePresentation
{
    public class EnrichmentAndDecay : MonoBehaviour
    {
        [SerializeField] private Button _button;
        public Button Button => _button;
        [SerializeField] private Slider _timer;
        public Slider Timer => _timer;
        [SerializeField] private ResourceType _resourceType;
        public ResourceType ResourceType => _resourceType;
        private float _enrichmentTime;
        public float EnrichmentTime => _enrichmentTime;
        private float _decayTime;
        public float DecayTime => _decayTime;
        

        private void Start()
        {
            _enrichmentTime = DataService.Source.GetEnrichmentTime(_resourceType);
            _decayTime = DataService.Source.GetDecayTime(_resourceType);

            _button.onClick.AddListener(StartEnrichmentTimer);
            TimerService.Source.StartTimer(this);
        }

        public void StartDecayTimer()
        {
            _button.interactable = true;
            ViewService.Source.SetEnabledSprite(gameObject);
        }

        private void StartEnrichmentTimer()
        {
            _button.interactable = false;
            ViewService.Source.SetDisabledSprite(gameObject);
            TimerService.Source.SetTimeToEnrichmentTimer(this);
        }
    }
}
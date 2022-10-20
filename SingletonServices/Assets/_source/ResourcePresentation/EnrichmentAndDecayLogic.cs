using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;
using Services;

namespace ResourcePresentation
{
    public class EnrichmentAndDecayLogic : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Slider _timer;
        [SerializeField] private Bootstrapper _bootstrapper;
        [SerializeField] private ResourceType _resourceType;
        public ResourceType ResourceType => _resourceType;
        private float _enrichmentTime;
        private float _decayTime;


        private void Awake()
        {
            StartDecayTimer();
            _button.onClick.AddListener(StartEnrichmentTimer);
        }
        private void Update()
        {
            if (_button.interactable)
            {
                _decayTime -= Time.deltaTime;
                TimerService.Source.UpdateTimer(_timer);
            }
            else
            {
                _enrichmentTime -= Time.deltaTime;
                TimerService.Source.UpdateTimer(_timer);
            }


            if (_enrichmentTime <= 0)
                StartDecayTimer();


            if(_decayTime <= 0)
            {
                _bootstrapper.Game.Quit();
            }
        }

        private void SetTimers()
        {
            _enrichmentTime = DataService.Source.GetEnrichmentTime(_resourceType);
            _decayTime = DataService.Source.GetDecayTime(_resourceType);
        }

        private void StartDecayTimer()
        {
            SetTimers();

            _button.interactable = true;
            TimerService.Source.SetTimeToTimer(_timer, _decayTime);
            ViewService.Source.SetEnabledSprite(gameObject);
        }

        private void StartEnrichmentTimer()
        {
            _button.interactable = false;
            TimerService.Source.SetTimeToTimer(_timer, _enrichmentTime);
            ViewService.Source.SetDisabledSprite(gameObject);
        }
    }
}
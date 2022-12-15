using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] List<Color> _skyColors;
    [SerializeField] private Transform _sun;
    [SerializeField] List<Transform> _sunPositions;
    [SerializeField] List<SpriteRenderer> _starRenderers;
    [SerializeField] List<float> _fadeValues;

    private void Start()
    {
        new Sky(_timer, _mainCamera, _skyColors);
        new Sun(_timer, _sun, _sunPositions);
        new Star(_timer, _starRenderers, _fadeValues);

        _timer.NotifyObservers();
    }
}
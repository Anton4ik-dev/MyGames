using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

class Sun : IObserver
{
    private Transform _sunPosition;
    private List<Transform> _positions;
    IObservable timer;
    public Sun(IObservable obs, Transform sunPosition, List<Transform> positions)
    {
        timer = obs;
        _sunPosition = sunPosition;
        _positions = positions;
        timer.AddObserver(this);
    }
    public void Update(int partOfDay, float partOfDayDuration)
    {
        _sunPosition.DOMove(_positions[partOfDay].position, partOfDayDuration);
    }
}
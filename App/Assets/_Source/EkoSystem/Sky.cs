using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

class Sky : IObserver
{
    private Camera _mainCamera;
    private List<Color> _colors;
    IObservable timer;
    public Sky(IObservable obs, Camera camera, List<Color> colors)
    {
        timer = obs;
        _colors = colors;
        _mainCamera = camera;
        timer.AddObserver(this);
    }
    public void Update(int partOfDay, float partOfDayDuration)
    {
        _mainCamera.DOColor(_colors[partOfDay], partOfDayDuration);
    }
}
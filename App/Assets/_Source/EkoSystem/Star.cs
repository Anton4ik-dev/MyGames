using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

class Star : IObserver
{
    private List<SpriteRenderer> _stars;
    private List<float> _fades;
    IObservable timer;
    public Star(IObservable obs, List<SpriteRenderer> stars, List<float> fades)
    {
        timer = obs;
        _stars = stars;
        _fades = fades;
        timer.AddObserver(this);
    }
    public void Update(int partOfDay, float partOfDayDuration)
    {
        for (int i = 0; i < _stars.Count; i++)
        {
            _stars[i].DOFade(_fades[partOfDay], partOfDayDuration);
        }
    }
}
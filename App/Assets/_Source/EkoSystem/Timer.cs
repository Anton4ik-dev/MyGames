using System.Collections.Generic;
using UnityEngine;

class Timer : MonoBehaviour, IObservable
{
    [SerializeField] private float _timeOfDay;
    private List<IObserver> _observers;
    private int _partOfDay = 0;
    private float _partOfDayDuration;
    private void SetTimeDuration()
    {
        _partOfDayDuration = _timeOfDay / 5;
    }
    public void AddObserver(IObserver o)
    {
        _observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        _observers.Remove(o);
    }

    public void NotifyObservers()
    {
        SetTimeDuration();
        foreach (IObserver o in _observers)
        {
            o.Update(_partOfDay, _partOfDayDuration);
        }
        _partOfDay++;
        if (_partOfDay == 5)
            _partOfDay = 0;
    }
    private void Awake()
    {
        _observers = new List<IObserver>();
    }
    private void Update()
    {
        if(_partOfDayDuration <= 0)
        {
            NotifyObservers();
        }

        _partOfDayDuration -= Time.deltaTime;
    }
}
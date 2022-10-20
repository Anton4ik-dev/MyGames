using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class MainTimer : MonoBehaviour
    {
        [SerializeField] private Text _mainTimer;
        private float _time = 0f;
        private bool isStopped = true;
        private void Update()
        {
            if (isStopped == false)
            {
                _time += Time.deltaTime;
                _mainTimer.text = $"{_time}";
            }
        }
        public void StartTimer()
        {
            isStopped = false;
        }
        public void StopTimer()
        {
            isStopped = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public sealed class TimerService
    {
        // ���� ������ �� ���������, ��� ��� ���� � ���-�� �� ��� ����� ������, �� ���� ���� �� �����) 
        private TimerService()
        {
        }
        private static TimerService source = null;
        public static TimerService Source
        {
            get
            {
                if (source == null)
                    source = new TimerService();

                return source;
            }
        }
        public void UpdateTimer(Slider timer)
        {
            timer.value -= Time.deltaTime;
        }
        public void SetTimeToTimer(Slider timer, float time)
        {
            timer.maxValue = time;
            timer.value = time;
        }
    }
}
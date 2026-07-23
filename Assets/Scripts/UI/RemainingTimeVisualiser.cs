using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RemainingTimeVisualiser: MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private Text bigText;

        private GlobalTimer _timer;

        public void Init(GlobalTimer timer)
        {
            _timer = timer;
            enabled = true;
        }

        private void OnSecondsHadChanged(int seconds, int minutes)
        {
            if (minutes == 0 && seconds <= 10)
            {
                text.enabled = false;
                bigText.enabled = true;
                bigText.text = $"{seconds}";
            }
            text.text = $"{minutes}:{seconds:00}";
        }

        private void OnEnable()
        {
            _timer.SecondsHadChanged += OnSecondsHadChanged;
        }

        private void OnDisable()
        {
            _timer.SecondsHadChanged -= OnSecondsHadChanged;
        }
    }
}
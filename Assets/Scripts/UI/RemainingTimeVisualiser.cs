using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RemainingTimeVisualiser: MonoBehaviour
    {
        [SerializeField] private Text text;

        private GlobalTimer _timer;

        public void Init(GlobalTimer timer)
        {
            _timer = timer;
            enabled = true;
        }

        private void OnSecondsHadChanged(int seconds, int minutes)
        {
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
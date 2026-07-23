using System;
using UnityEngine;

namespace Goals
{
    public class FuelFillingGoal : MonoBehaviour, IGoal
    {
        [SerializeField] private Trigger trigger;
        [SerializeField] private float timeToFill;
        
        public event Action<IGoal> WasReached;

        private Transform _filler;
        private float _fillProgress;
        private bool _wasCompleted;

        public void Init(Transform filler)
        {
            _filler = filler;
        }

        private void Update()
        {
            if (_wasCompleted)
                return;
            
            if (!trigger.Objects.Contains(_filler))
                return;
            
            _fillProgress += Time.deltaTime;
            if (_fillProgress < timeToFill) 
                return;
            
            _wasCompleted = true;
            WasReached?.Invoke(this);
        }
    }
}
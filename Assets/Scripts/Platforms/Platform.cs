using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Trigger trigger;

        private Transform _transform;
        private Vector3 _lastPosition;

        private void Awake()
        {
            _transform = transform;
            _lastPosition = _transform.position;
        }

        private void Update()
        {
            var delta = _transform.position - _lastPosition;
            _lastPosition = _transform.position;
            foreach (var element in trigger.Objects) 
                element.position += delta;
        }
    }
}
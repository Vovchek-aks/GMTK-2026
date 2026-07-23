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
        private readonly List<Transform> _cargo = new List<Transform>();

        private void Awake()
        {
            _transform = transform;
            _lastPosition = _transform.position;
        }

        private void Update()
        {
            var delta = _transform.position - _lastPosition;
            _lastPosition = _transform.position;
            foreach (var element in _cargo) 
                element.position += delta;
        }

        private void OnEntered(Collider other)
        {
            _cargo.Add(other.transform);
        }

        private void OnExited(Collider other)
        {
            _cargo.Remove(other.transform);
        }

        private void OnEnable()
        {
            trigger.Entered += OnEntered;
            trigger.Exited += OnExited;
        }
        
        private void OnDisable()
        {
            trigger.Entered -= OnEntered;
            trigger.Exited -= OnExited;
        }
    }
}
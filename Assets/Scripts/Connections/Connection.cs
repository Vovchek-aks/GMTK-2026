using System;
using UnityEngine;

namespace Connections
{
    [RequireComponent(typeof(Rigidbody))]
    public class Connection: MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Trigger trigger;
        [SerializeField] private float connectionForce;
        
        private Rigidbody _rigidbody;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (trigger.Objects.Contains(target))
                return;

            var delta = target.position - _transform.position;
            _rigidbody.AddForceAtPosition(delta.normalized * connectionForce, _transform.position);
        }
    }
}
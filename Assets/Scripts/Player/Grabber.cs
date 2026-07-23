using System;
using Interactables;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInteracter))]
    public class Grabber : MonoBehaviour
    {
        [SerializeField] private Transform head;
        [SerializeField] private float distance = 1f;
        
        private PlayerInteracter _interacter;
        private ICanBeGrabbed _grabbed;

        private void Awake() => 
            _interacter = GetComponent<PlayerInteracter>();

        private void FixedUpdate()
        {
            if (_grabbed == null)
                return;

            _grabbed.Rigidbody.velocity = 10 * (head.position + head.forward * distance - _grabbed.Transform.position);
            _grabbed.Rigidbody.angularVelocity *= .9f;
        }

        private void TryGrab(IInteractable interactable, Interaction press)
        {
            if (press != Interaction.Main)
                return;

            if (_grabbed != null)
            {
                Release();
                return;
            }

            var grabbed = interactable?.gameObject.GetComponent<ICanBeGrabbed>();
            if (grabbed == null)
                return;

            _grabbed = grabbed;
            _grabbed.OnGrab(this);
        }

        public void Release()
        {
            if (_grabbed == null)
                throw new InvalidOperationException(nameof(_grabbed));
            
            _grabbed.OnRelease(this);
            _grabbed = null;
        }

        private void OnEnable() => 
            _interacter.Interacted += TryGrab;

        private void OnDisable() => 
            _interacter.Interacted -= TryGrab;
    }
}
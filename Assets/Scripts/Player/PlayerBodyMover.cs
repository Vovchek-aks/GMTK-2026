using System;
using Interactables;
using UnityEngine;
// ReSharper disable Unity.PerformanceCriticalCodeInvocation

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerBodyMover : PlayerMover
    {
        [SerializeField] private float speed;
        [SerializeField] private float gravity = Physics.gravity.magnitude;
        [SerializeField] private float targetFlightHeight;

        private Vector3 _direction = Vector3.zero;

        private void FixedUpdate()
        {
            Rigidbody.velocity = _direction * speed + GetVerticalVelocity(Time.fixedDeltaTime);
            _direction = Vector3.zero;
        }

        private Vector3 GetVerticalVelocity(float dt)
        {
            var height = GetHeight();
            if (!IsGrounded(height))
                return Vector3.up * (Rigidbody.velocity.y - gravity * dt);

            var delta = height - targetFlightHeight;
            return Vector3.down * (delta * 10);
        }

        private bool IsGrounded(float height) => height < targetFlightHeight * 2;
        private bool IsGrounded() => IsGrounded(GetHeight());

        private float GetHeight()
        {
            const float radius = 1f;
            var ray = new Ray(Transform.position + Vector3.up * .1f, Vector3.down * radius);
            if (!Physics.SphereCast(ray, radius, out var hit, targetFlightHeight * 2))
                return float.PositiveInfinity;

            var rb = hit.transform.GetComponent<ICanBeGrabbed>();
            if (rb != null)
                return float.PositiveInfinity;

            return hit.distance;
        }

        private void ReceiveMovement(Vector2 direction)
        {
            if (Math.Abs(direction.sqrMagnitude - 1) > .001f)
                throw new InvalidOperationException(nameof(direction));
            
            if (!IsGrounded())
                return;
            
            var angle = (float) (-Transform.rotation.eulerAngles.y / 180 * Math.PI);
            direction = direction.Rotate(angle);
            var dir3 = new Vector3(direction.x, 0, direction.y);
            
            _direction = dir3;
        }

        private void OnEnable() => 
            Inputer.NeedToMove += ReceiveMovement;

        private void OnDisable() => 
            Inputer.NeedToMove -= ReceiveMovement;
    }
}
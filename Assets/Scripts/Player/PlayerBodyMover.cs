using System;
using Interactables;
using UnityEngine;
using UnityEngine.Serialization;

// ReSharper disable Unity.PerformanceCriticalCodeInvocation

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerBodyMover : PlayerMover
    {
        [FormerlySerializedAs("speed")] 
        [SerializeField] private float walkSpeed;
        [SerializeField] private float sprintSpeed;
        [SerializeField] private float jumpVerticalSpeed;
        [SerializeField] private float gravity = Physics.gravity.magnitude;
        [SerializeField] private float targetFlightHeight;
        [SerializeField] [Range(0, 1)] private float airControlRatio;

        private Vector3 _horizontalDirection = Vector3.zero;
        private float _speed = 0;
        private bool _needToJump = false;
        private bool _isGrounded = true;

        private void FixedUpdate()
        {
            _isGrounded = IsGrounded();
            Rigidbody.velocity = _horizontalDirection * _speed + GetVerticalVelocity(Time.fixedDeltaTime);
            
            _needToJump = false;
            if (_isGrounded)
                _horizontalDirection = Vector3.zero;
        }

        private Vector3 GetVerticalVelocity(float dt)
        {
            if (_needToJump)
                return Vector3.up * jumpVerticalSpeed;
            
            if (Rigidbody.velocity.y > 0 || !_isGrounded)
                return Vector3.up * (Rigidbody.velocity.y - gravity * dt);

            var delta = GetHeight() - targetFlightHeight;
            return Vector3.down * (delta * 10);
        }

        private bool IsGrounded(float height) => height < targetFlightHeight * 2;
        private bool IsGrounded() => IsGrounded(GetHeight());

        private float GetHeight()
        {
            const float radius = 1f;
            var ray = new Ray(Transform.position + Vector3.up * .1f, Vector3.down * radius);
            if (!Physics.SphereCast(ray, radius, out var hit, targetFlightHeight * 2, 1, 
                    QueryTriggerInteraction.Ignore))
                return float.PositiveInfinity;

            var rb = hit.transform.GetComponent<ICanBeGrabbed>();
            if (rb != null)
                return float.PositiveInfinity;

            return hit.distance;
        }

        private void ReceiveMovement(Vector2 direction, bool isSprinting)
        {
            if (Math.Abs(direction.sqrMagnitude - 1) > .001f)
                throw new InvalidOperationException(nameof(direction));
            
            var angle = (float) (-Transform.rotation.eulerAngles.y / 180 * Math.PI);
            direction = direction.Rotate(angle);
            var dir3 = new Vector3(direction.x, 0, direction.y);
            
            _horizontalDirection = _isGrounded ? dir3 : _horizontalDirection.Lerp(dir3, airControlRatio);
            _speed = isSprinting ? sprintSpeed : walkSpeed;
        }

        private void Jump()
        {
            if (_isGrounded)
                _needToJump = true;
        }

        private void OnEnable()
        {
            Inputer.NeedToMove += ReceiveMovement;
            Inputer.NeedToJump += Jump;
        }

        private void OnDisable()
        {
            Inputer.NeedToMove -= ReceiveMovement;
            Inputer.NeedToJump -= Jump;
        }
    }
}
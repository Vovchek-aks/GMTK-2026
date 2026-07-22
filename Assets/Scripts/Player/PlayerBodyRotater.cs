using System;
using UnityEngine;

namespace Player
{
    public class PlayerBodyRotater : PlayerMover
    {
        [SerializeField] private float speed;
        
        
        private float _angle = 0;
        
        private void OnEnable() => Inputer.NeedToRotateBody += ReceiveRotation;
        private void OnDisable() => Inputer.NeedToRotateBody -= ReceiveRotation;

        private void FixedUpdate()
        {
            Transform.Rotate(Vector3.up * (_angle * speed * Time.deltaTime));

            _angle = 0;
        }

        private void ReceiveRotation(float angle) => _angle = angle;
        
    }
}
using System;
using UnityEngine;

namespace Player
{
    public class PlayerHeadRotater: PlayerMover
    {
        [SerializeField] private float speed;
        
        [SerializeField] private Transform head;
        
        private float _angle = 0;


        private static float FixedAngle(float angle) => (float) Math.Sin((.5f + angle / 180) * Math.PI);

        private void FixedUpdate()
        {
            var originalRotation = head.rotation;
            head.Rotate(Vector3.left * (_angle * speed * Time.deltaTime));
            if (FixedAngle(head.rotation.eulerAngles.x) < .2f)
                head.rotation = originalRotation;

            _angle = 0;
        }

        private void ReceiveRotation(float angle) => _angle = angle;
        
        private void OnEnable() => 
            Inputer.NeedToRotateHead += ReceiveRotation;
        
        private void OnDisable() => 
            Inputer.NeedToRotateHead -= ReceiveRotation;
    }
}
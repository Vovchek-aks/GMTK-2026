using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platforms
{
    public class ElevatorMover : MonoBehaviour
    {
        [SerializeField] private float meanSpeed;
        [SerializeField] private float reachProgress = 0.1f;
        [SerializeField] private List<Transform> targets;
        
        private Transform _transform;
        private Vector3 _position;
        private int _index = 0;
        private Coroutine _coroutine;

        private Transform Target => targets[_index]; 
        
        private void Awake() => 
            _transform = transform;

        private void Start() => 
            _coroutine = StartCoroutine(WalkThroughTargets());

        private void Update()
        {
            _transform.position = _position;
        }

        private IEnumerator WalkThroughTargets()
        {
            while (true)
            {
                yield return StartCoroutine(MoveToTarget(Target));
                _index = (_index + 1) % targets.Count;
            }
        }

        private IEnumerator MoveToTarget(Transform target)
        {
            var position = _transform.position;
            var delta = target.position - position;
            var time = delta.magnitude / meanSpeed;
            var startMovementTime = Time.fixedTime;
            var endMovementTime = startMovementTime + time;
            
            var progress = 0f;
            while (1 - progress > reachProgress)
            {
                _position = position.Lerp(target.position, progress);
                var x = Time.fixedTime.GetLerpProgress(startMovementTime, endMovementTime);
                progress = (1 - Mathf.Cos(Mathf.PI * x)) / 2;

                yield return null;
            }
        }
    }
}
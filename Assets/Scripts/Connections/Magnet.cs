using UnityEngine;
using UnityEngine.Serialization;

namespace Connections
{
    [RequireComponent(typeof(Rigidbody))]
    public class Magnet : MonoBehaviour
    {
        [field: SerializeField] private Transform Target { set; get; }
        [FormerlySerializedAs("forceTrigger")] 
        [SerializeField] private Trigger trigger;
        [SerializeField] private float connectionForce;
        
        public Transform Transform { private set; get; }
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            Transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetTarget(Transform target)
        {
            Target = target;
        }

        private void FixedUpdate()
        {
            if (!trigger.Objects.Contains(Target))
                return;

            var delta = Target.position - trigger.Transform.position;
            _rigidbody.AddForceAtPosition(delta.normalized * connectionForce, trigger.Transform.position);
        }
    }
}
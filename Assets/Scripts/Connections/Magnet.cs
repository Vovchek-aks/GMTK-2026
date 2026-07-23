using UnityEngine;
using UnityEngine.Serialization;

namespace Connections
{
    [RequireComponent(typeof(Rigidbody))]
    public class Magnet : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [FormerlySerializedAs("forceTrigger")] 
        [SerializeField] private Trigger trigger;
        [SerializeField] private float connectionForce;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (!trigger.Objects.Contains(target))
                return;

            var delta = target.position - trigger.Transform.position;
            _rigidbody.AddForceAtPosition(delta.normalized * connectionForce, trigger.Transform.position);
        }
    }
}
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInputer))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class PlayerMover : MonoBehaviour
    {
        protected PlayerInputer Inputer { private set; get; }
        protected Rigidbody Rigidbody { private set; get; }
        protected Transform Transform { private set; get; }

        protected virtual void Awake()
        {
            Inputer = GetComponent<PlayerInputer>();
            Rigidbody = GetComponent<Rigidbody>();
            Transform = transform;
        }
    }
}
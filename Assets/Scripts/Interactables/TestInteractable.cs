using System;
using Player;
using UnityEngine;

namespace Interactables
{
    public class TestInteractable : MonoBehaviour, ICanBeGrabbed
    {
        public Rigidbody Rigidbody { private set; get; }
        public Transform Transform { private set; get; }


        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Transform = transform;
        }

        public void OnInteract(Interaction interaction) { }
        public void OnGrab(Grabber grabber) { }
        public void OnRelease(Grabber grabber) { }
        
    }
}
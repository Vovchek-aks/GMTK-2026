using System;
using Interactables;
using UnityEngine;

namespace Player
{
    public class PlayerInteracter : MonoBehaviour
    {
        [SerializeField] private float maxDistance = 10f;
        [SerializeField] private Transform head;

        public event Action<IInteractable, Interaction> Interacted; 
        
        private PlayerInputer _inputer;
          
        private void Awake()
        {
            _inputer = GetComponent<PlayerInputer>();
        }

        private void Interact(Interaction press)
        {
            
            var ray = new Ray(head.position, head.forward);
            if (!Physics.Raycast(ray, out var hit, maxDistance, 1, QueryTriggerInteraction.Ignore))
                return;
            
            var interactable = hit.transform.GetComponent<IInteractable>();
            if (interactable == null)
                return;
            
            interactable.OnInteract(press);
            Interacted?.Invoke(interactable, press);
        }

        private void OnEnable()
        {
            _inputer.NeedToInteract += Interact;
        }
        
        private void OnDisable()
        {
            _inputer.NeedToInteract -= Interact;
        }
    }
}
using System;
using System.Collections.Generic;
using Interactables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputer : MonoBehaviour
    {
        public event Action<Interaction> NeedToInteract;
        public event Action NeedToJump;
        
        public event Action<Vector2, bool> NeedToMove; 
        public event Action<float> NeedToRotateBody; 
        public event Action<float> NeedToRotateHead;

        private FPCInputer _fpcInputer;
        private InputAction _move;

        private Mouse _mouse;
        
        private static readonly Dictionary<Vector2, Interaction> Interaction = 
            new Dictionary<Vector2, Interaction>()
            {
                [new Vector2(1f, 0f)] = Interactables.Interaction.Main,
                [new Vector2(0f, 1f)] = Interactables.Interaction.Secondary,
                [new Vector2(1f, 1f)] = Interactables.Interaction.Both,
            };
        
        private void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            _fpcInputer = new FPCInputer();
            _move = _fpcInputer.KB.Walk;
            
            _mouse = Mouse.current;
        }
        
        public void Update()
        {
            InvokeMovement();
            InvokeRotations();
            Cursor.visible = false;
        }
        
        private void InvokeMovement()
        {
            var move = _move.ReadValue<Vector2>();
            if (move.sqrMagnitude != 0)
                NeedToMove?.Invoke(move, _fpcInputer.KB.Sprint.ReadValue<float>() > 0);
        }
        
        private void InvokeRotations()
        {
            var delta = _mouse.delta.ReadValue();
            if (delta.x != 0)
                NeedToRotateBody?.Invoke(delta.x);
            if (delta.y != 0)
                NeedToRotateHead?.Invoke(delta.y);
        }

        private void InvokeInteraction(InputAction.CallbackContext context) => 
            NeedToInteract?.Invoke(Interaction[context.ReadValue<Vector2>()]);
        
        private void InvokeJump(InputAction.CallbackContext context) => 
            NeedToJump?.Invoke();
        
        private void OnEnable()
        {
            _fpcInputer.Enable();
            _move.Enable();
            
            _fpcInputer.KB.Interact.started += InvokeInteraction;
            _fpcInputer.KB.Jump.started += InvokeJump;
        }
        
        private void OnDisable()
        {
            _fpcInputer.KB.Interact.started -= InvokeInteraction;
            _fpcInputer.KB.Jump.started -= InvokeJump;
            
            _move.Disable();
            _fpcInputer.Disable();
        }
    }
}
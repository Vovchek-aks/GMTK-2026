// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/FPC Inputer.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FPCInputer : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FPCInputer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FPC Inputer"",
    ""maps"": [
        {
            ""name"": ""KB"",
            ""id"": ""ee6dc690-3582-4cd7-8faf-9289ace7e567"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9f7ac216-8e7e-4c21-a860-04b61ce21f4f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Value"",
                    ""id"": ""fd3a85e2-0301-4266-9e6b-afa5416d15e7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""30aee585-8b0b-45f5-9141-af590a751687"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""00f68a97-ed30-4fff-83e0-a3f4942d542f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ea4b0955-c126-4994-b068-9a2e6a9f7865"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dc77ccdb-351b-4b45-968d-c3e64e99ea6b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4d96f30a-021d-4a50-8a93-f8424a470fe9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""id"": ""29a3ea8d-19ff-4ce8-8f87-c062669a8a70"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7d810321-e750-420f-9b19-7fb8268fed35"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""21f2a24d-ff76-4b74-a6f8-151c14fd7060"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7f10e81f-131a-487a-9ae5-3a9a94538bf3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3813830b-0525-4c87-add9-1a10cc546945"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""E"",
                    ""id"": ""78f59389-5de4-4c2b-a3fb-ad0ca8e6c222"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1043cc57-d9b5-4c74-ac3b-e25f91d246b4"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f4b7494b-eba3-4cf8-a623-155ae49b728e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2151e4da-49d1-43fb-b4f4-2e962fb5083d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e5ed3445-60c9-4e8b-9a04-fd87f44fe5a6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KB
        m_KB = asset.FindActionMap("KB", throwIfNotFound: true);
        m_KB_Walk = m_KB.FindAction("Walk", throwIfNotFound: true);
        m_KB_Interact = m_KB.FindAction("Interact", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // KB
    private readonly InputActionMap m_KB;
    private IKBActions m_KBActionsCallbackInterface;
    private readonly InputAction m_KB_Walk;
    private readonly InputAction m_KB_Interact;
    public struct KBActions
    {
        private @FPCInputer m_Wrapper;
        public KBActions(@FPCInputer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_KB_Walk;
        public InputAction @Interact => m_Wrapper.m_KB_Interact;
        public InputActionMap Get() { return m_Wrapper.m_KB; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KBActions set) { return set.Get(); }
        public void SetCallbacks(IKBActions instance)
        {
            if (m_Wrapper.m_KBActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_KBActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_KBActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_KBActionsCallbackInterface.OnWalk;
                @Interact.started -= m_Wrapper.m_KBActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_KBActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_KBActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_KBActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public KBActions @KB => new KBActions(this);
    public interface IKBActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}

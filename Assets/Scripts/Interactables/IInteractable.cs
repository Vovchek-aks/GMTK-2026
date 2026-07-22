using UnityEngine;

namespace Interactables
{
    public interface IInteractable
    {
        void OnInteract(Interaction interaction);

        GameObject gameObject { get; }
    }

    public enum Interaction  
    {
        Main,
        Secondary,
        Both
    }
}
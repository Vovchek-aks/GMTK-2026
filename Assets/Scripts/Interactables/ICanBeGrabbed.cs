using Player;
using UnityEngine;

namespace Interactables
{
    public interface ICanBeGrabbed: IInteractable
    {
        Rigidbody Rigidbody { get; }
        Transform Transform { get; }

        void OnGrab(Grabber grabber);
        void OnRelease(Grabber grabber);
    }
}
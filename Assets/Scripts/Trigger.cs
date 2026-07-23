using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    public event Action<Collider> Entered;
    public event Action<Collider> Exited;
    
    public Transform Transform { private set; get; }
    
    private void Awake() => 
        Transform = transform;
    
    private void OnTriggerEnter(Collider other) => Entered?.Invoke(other);
    private void OnTriggerExit(Collider other) => Exited?.Invoke(other);
}
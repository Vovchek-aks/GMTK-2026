using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    public event Action<Collider> Entered;
    public event Action<Collider> Exited;
    
    public List<Transform> Objects { get; } = new List<Transform>();
    
    public Transform Transform { private set; get; }
    
    private void Awake() => 
        Transform = transform;
    
    private void OnTriggerEnter(Collider other)
    {
        Objects.Add(other.transform);
        Entered?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        Objects.Remove(other.transform);
        Exited?.Invoke(other);
    }
}
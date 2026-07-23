using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private BarrelIniter barrelIniter;
    [SerializeField] private Transform barrelConnecterTarget;

    private void Start()
    {
        barrelIniter.Init(barrelConnecterTarget);
    }
}
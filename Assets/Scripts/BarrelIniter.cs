using Connections;
using UnityEngine;

public class BarrelIniter: MonoBehaviour
{
    [SerializeField] private Magnet connectorMagnet;

    public void Init(Transform connectorTarget)
    {
        connectorMagnet.SetTarget(connectorTarget);
    }
}
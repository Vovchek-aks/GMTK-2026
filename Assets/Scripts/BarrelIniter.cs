using Connections;
using UnityEngine;

public class BarrelIniter: MonoBehaviour
{
    [SerializeField] private Magnet connectorMagnet;

    public Transform Connector => connectorMagnet.Transform;
    
    public void Init(Transform connectorTarget)
    {
        connectorMagnet.SetTarget(connectorTarget);
    }
}
using System;
using UnityEngine;

namespace Connections
{
    public class ConnectionLineDrawer : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private Connection connection;
        [SerializeField] private Transform cylinder;


        private void Update()
        {
            cylinder.position = (connection.Position + connection.Target.position) / 2f;

            var delta = connection.Position - connection.Target.position;
            cylinder.localScale = new Vector3(radius, delta.magnitude, radius);

            cylinder.rotation = Quaternion.FromToRotation(Vector3.up, delta.normalized);
        }
    }
}
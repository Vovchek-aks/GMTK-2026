using UnityEngine;
using UnityEngine.InputSystem;

public class Exiter : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
            Application.Quit();
    }
}
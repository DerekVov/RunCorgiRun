using UnityEngine;
using UnityEngine.InputSystem;
public class KeyboardInput : MonoBehaviour
{
    public Corgi corgi;
    public void Update()
    {
        // gets new button pressed

        Keyboard keyboard = Keyboard.current;
        if (keyboard.wKey.isPressed)
        {
            //up
            corgi.Move(Vector2.up);
        }
        if (keyboard.aKey.isPressed)
        {
            // left
            corgi.Move(Vector2.left);
        }
        if (keyboard.sKey.isPressed)
        {
            // down 
            corgi.Move(Vector2.down);
        }
        if (keyboard.dKey.isPressed)
        {
            // right
            corgi.Move(Vector2.right);
        }

        // move corgi
    }
}

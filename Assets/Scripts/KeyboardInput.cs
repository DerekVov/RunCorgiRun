using UnityEngine;
using UnityEngine.InputSystem;
public class KeyboardInput : MonoBehaviour
{
    public Corgi corgi;
    public PoopPlacer poopPlacer;
    public void Update()
    {
        // gets new button pressed

        Keyboard keyboard = Keyboard.current;
        if (keyboard.wKey.isPressed)
        {
            //up
            corgi.MoveManually(Vector2.up);
        }
        if (keyboard.aKey.isPressed)
        {
            // left
            corgi.MoveManually(Vector2.left);
        }
        if (keyboard.sKey.isPressed)
        {
            // down 
            corgi.MoveManually(Vector2.down);
        }
        if (keyboard.dKey.isPressed)
        {
            // right
            corgi.MoveManually(Vector2.right);
        }

        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            poopPlacer.Place(corgi.GetPosition());
        }

        // move corgi
    }
}

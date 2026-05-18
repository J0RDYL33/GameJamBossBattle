using UnityEngine;
using UnityEngine.InputSystem;

public class SideBossBehaviour : MonoBehaviour
{
    private SpriteRenderer sr;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnButtonNorth(InputAction.CallbackContext context)
    {
        if (context.performed) sr.color = Color.red;
    }

    public void OnButtonEast(InputAction.CallbackContext context)
    {
        if (context.performed) sr.color = Color.yellow;
    }

    public void OnButtonWest(InputAction.CallbackContext context)
    {
        if (context.performed) sr.color = Color.blue;
    }

    public void OnButtonSouth(InputAction.CallbackContext context)
    {
        if (context.performed) sr.color = Color.green;
    }
}

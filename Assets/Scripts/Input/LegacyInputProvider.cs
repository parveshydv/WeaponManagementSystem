using UnityEngine;

// Handles basic player input such as firing, reloading, and scrolling weapons
public class LegacyInputProvider : MonoBehaviour, IInputProvider
{
    public bool FireHeld() => Input.GetButton("Fire1");
    public bool FirePressed() => Input.GetButtonDown("Fire1");
    public bool ReloadPressed() => Input.GetKeyDown(KeyCode.R);

    public int ScrollDelta()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll > 0) return +1;
        if (scroll < 0) return -1;
        return 0;
    }
}

public interface IInputProvider // Interface that defines the basic player controls
{
    bool FireHeld(); // True while the fire button is held down
    bool FirePressed(); // True only on the moment the fire button is pressed
    bool ReloadPressed(); // True when the reload key is pressed
    int ScrollDelta();  //  // Mouse scroll direction used to change weapons
}
